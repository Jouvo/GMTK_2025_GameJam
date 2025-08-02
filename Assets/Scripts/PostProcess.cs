using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcess : MonoBehaviour
{
    // 修改的后处理滤镜类型
    public Volume volume;
    public float SwitchSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
