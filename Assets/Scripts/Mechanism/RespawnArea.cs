using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnArea : MonoBehaviour
{
    private GameObject player;  //��ȡ��Ҷ���
    public Transform rpPos;   //��ȡ��Ӧ����ĳ�����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ����ҽ�������ʱ�л�������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            PlayerMovement PM = player.GetComponent<PlayerMovement>();
            PM.respawnPoint = rpPos.position;
        }
    }
}
