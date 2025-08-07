using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static StateMgr;

public class PostProcess : MonoBehaviour
{
    GameMgr gameMgr;
    // 修改的后处理滤镜类型
    public Volume volume;
    public float SwitchSpeed = 0.5f;
    public bool isDefault=false;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();

        gameMgr = GameMgr.Instance;
        if (isDefault)
        {
            // 注册状态切换事件
            StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
            if (gameMgr.isIce == true)
            {
                InitiatePPV(1);
            }
            else if (gameMgr.isIce == false)
            {
                InitiatePPV(0);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitiatePPV(int isIce)
    {
        // 使用插值函数逐渐改变权重
        volume.weight = isIce;
    }

    public IEnumerator LerpPPV(float LerpTime)
    {
        Debug.Log("开始Lerp！");
        float elapsedTime = 0f;
        float startWeight = volume.weight;
        //float endWeight = 1; // 这里可以根据需要修改目标权重
        float endWeight = (volume.weight > 0.9) ? 0 : 1; // 若当前为1，则变为0；若为0，则变为1
        while (elapsedTime < LerpTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / LerpTime); // 保证 t 在 [0, 1] 范围内

            // 使用插值函数逐渐改变权重
            volume.weight = Mathf.Lerp(startWeight, endWeight, t);
            Debug.Log("Lerping");
            yield return null;
        }
        Debug.Log("Lerp完成！");
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // 冰模式
                // 调用滤镜协程
                StartCoroutine(LerpPPV(SwitchSpeed));
                break;
            case EnvironmentState.Fire: // 火模式
                // 调用滤镜协程
                StartCoroutine(LerpPPV(SwitchSpeed));
                break;
        }
    }

    private void OnDestroy()
    {
        // 取消注册避免内存泄漏
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }

}
