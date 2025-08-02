using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnArea : MonoBehaviour
{
    private GameObject player;  //获取玩家对象
    public Transform rpPos;   //获取对应区域的出生点

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 当玩家进入区域时切换重生点
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
