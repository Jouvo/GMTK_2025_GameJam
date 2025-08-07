using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static GameMgr;

public class Altar : MonoBehaviour
{
    private GameMgr gameMgr;
    // �޸ĵĺ����˾�����
    public Volume volume;
    public float LerpTime=1f;
    public AudioClip clip;

    private void Start()
    {
        gameMgr = GameMgr.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ˮ��δ����ʱ������ʾ����
            if (gameMgr.crystalID.Count < gameMgr.crystalSlots.Length)
            {
                gameMgr.spawnBubble(BubbleType.Crystal);
            }
            else    // ˮ������
            {
                // ������Ч
                SoundPlayer.Instance.PlaySounds(clip);
                GameMgr.Instance.Win();
                StartCoroutine(LerpPPV(LerpTime));
                Debug.Log("����ˮ����");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
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
        gameMgr.OpenWinPanel();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameMgr.Bubble != null)
            {
                gameMgr.Bubble.RemoveBubble();
            }
        }
    }
}
