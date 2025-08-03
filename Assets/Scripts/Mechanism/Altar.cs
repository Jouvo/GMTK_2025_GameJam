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
            // 水晶未集齐时弹出提示气泡
            if (gameMgr.crystalID.Count < gameMgr.crystalSlots.Length)
            {
                GameMgr.Instance.playerBubble.SetActive(true);
                gameMgr.Bubble.ChangeSprite(BubbleType.Crystal);
            }
            // 水晶集齐
            Debug.Log("集齐水晶！");
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
