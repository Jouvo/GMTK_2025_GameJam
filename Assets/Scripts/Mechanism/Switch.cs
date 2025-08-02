using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // µ±Íæ¼Ò½Ó´¥Ê±£¬ÇÐ»»×´Ì¬
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMgr.Instance.ToggleState();
            Debug.Log("ÇÐ»»×´Ì¬£º"+ StateMgr.Instance._currentState);
        }
    }
}
