using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static StateMgr;

public class IcePostProcess : MonoBehaviour
{
    // �޸ĵĺ����˾�����
    public Volume volume;
    public float SwitchSpeed = 0.5f;

    void Start()
    {
        volume= GetComponent<Volume>();

        // ע��״̬�л��¼�
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
    }

    IEnumerator LerpPPV(float LerpTime)
    {
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
            yield return null;
        }
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
