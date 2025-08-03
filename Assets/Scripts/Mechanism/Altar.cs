using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameMgr;

public class Altar : MonoBehaviour
{
    private GameMgr gameMgr;

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
                GameMgr.Instance.playerBubble.SetActive(true);
                gameMgr.Bubble.ChangeSprite(BubbleType.Crystal);
            }
            // ˮ������
            Debug.Log("����ˮ����");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameMgr.playerBubble.SetActive(false);
            gameMgr.Bubble.ChangeSprite(BubbleType.Crystal);
        }
    }
}
