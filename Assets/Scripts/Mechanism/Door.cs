using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D _collison;
    private GameMgr gameMgr;
    private bool isOpen = false;

    private void Start()
    {
        gameMgr = GameMgr.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseKey();
        }
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

    public void UseKey()
    {
        isOpen = gameMgr.UseKey();
        if(isOpen)
        {
            _collison.enabled = false;
        }
    }

}
