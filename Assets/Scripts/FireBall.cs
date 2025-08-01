using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 火球击中某物时
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FireBall命中物体");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
        {

        }
        else
        {

        }

        // 销毁子弹
        Destroy(gameObject);

    }

}
