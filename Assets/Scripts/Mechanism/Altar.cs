using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static GameMgr;

public class Altar : MonoBehaviour
{
    private GameMgr gameMgr;
    // 修改的后处理滤镜类型
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
            // 水晶未集齐时弹出提示气泡
            if (gameMgr.crystalID.Count < gameMgr.crystalSlots.Length)
            {
                gameMgr.spawnBubble(BubbleType.Crystal);
            }
            else    // 水晶集齐
            {
                // 播放音效
                SoundPlayer.Instance.PlaySounds(clip);
                GameMgr.Instance.Win();
                StartCoroutine(LerpPPV(LerpTime));
                Debug.Log("集齐水晶！");
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
        //float endWeight = 1; // 这里可以根据需要修改目标权重
        float endWeight = (volume.weight > 0.9) ? 0 : 1; // 若当前为1，则变为0；若为0，则变为1
        while (elapsedTime < LerpTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / LerpTime); // 保证 t 在 [0, 1] 范围内

            // 使用插值函数逐渐改变权重
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
