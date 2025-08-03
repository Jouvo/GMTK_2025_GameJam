using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMap : MonoBehaviour
{
    GameObject mainCam;
    float map_width = 50;
    float total_width;
    int mapNums = 4;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
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
