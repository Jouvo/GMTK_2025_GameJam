using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static StateMgr;

public class PostProcess : MonoBehaviour
{
    GameMgr gameMgr;
    // �޸ĵĺ����˾�����
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
            // ע��״̬�л��¼�
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
        // ʹ�ò�ֵ�����𽥸ı�Ȩ��
        volume.weight = isIce;
    }

    public IEnumerator LerpPPV(float LerpTime)
    {
        Debug.Log("��ʼLerp��");
        float elapsedTime = 0f;
        float startWeight = volume.weight;
        //float endWeight = 1; // ������Ը�����Ҫ�޸�Ŀ��Ȩ��
        float endWeight = (volume.weight > 0.9) ? 0 : 1; // ����ǰΪ1�����Ϊ0����Ϊ0�����Ϊ1
        while (elapsedTime < LerpTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / LerpTime); // ��֤ t �� [0, 1] ��Χ��

            // ʹ�ò�ֵ�����𽥸ı�Ȩ��
            volume.weight = Mathf.Lerp(startWeight, endWeight, t);
            Debug.Log("Lerping");
            yield return null;
        }
        Debug.Log("Lerp��ɣ�");
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // ��ģʽ
                // �����˾�Э��
                StartCoroutine(LerpPPV(SwitchSpeed));
                break;
            case EnvironmentState.Fire: // ��ģʽ
                // �����˾�Э��
                StartCoroutine(LerpPPV(SwitchSpeed));
                break;
        }
    }

    private void OnDestroy()
    {
        // ȡ��ע������ڴ�й©
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }

}
