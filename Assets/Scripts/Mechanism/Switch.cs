using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // ����ҽӴ�ʱ���л�״̬
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMgr.Instance.ToggleState();
            Debug.Log("�л�״̬��"+ StateMgr.Instance._currentState);
        }
    }
}
