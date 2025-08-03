using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D _collison;
    private GameMgr GameMgr;
    private bool isOpen = false;

    private void Start()
    {
        GameMgr = GameMgr.Instance;
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
            GameMgr.Instance.playerBubble.SetActive(false);
        }
    }

    public void UseKey()
    {
        isOpen = GameMgr.UseKey();
        if(isOpen)
        {
            _collison.enabled = false;
        }
    }

}
