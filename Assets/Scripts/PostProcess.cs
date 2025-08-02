using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcess : MonoBehaviour
{
    // �޸ĵĺ����˾�����
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

}
