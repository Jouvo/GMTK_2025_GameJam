using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMap : MonoBehaviour
{
    GameObject mainCam;
    GameMgr gameMgr;
    float map_width;
    float total_width;
    int mapNums;

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡgameMgr���õ�ģ�鳤�ȡ�����
        gameMgr = GameMgr.Instance;
        map_width=gameMgr.BlockWidth;
        mapNums = gameMgr.BlockNum;
        // ��ȡmainCamera
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        // ����ؿ��ܳ���
        total_width = map_width * mapNums;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loadMap_Position=transform.position;
        if (mainCam.transform.position.x > transform.position.x + total_width / 2)
        {
            loadMap_Position.x += total_width;
            transform.position = loadMap_Position;
        }
        else if (mainCam.transform.position.x < transform.position.x - total_width / 2)
        {
            loadMap_Position.x -= total_width;
            transform.position = loadMap_Position;
        }
    }
}
