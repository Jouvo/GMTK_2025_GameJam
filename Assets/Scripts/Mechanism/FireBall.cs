using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    // 火球击中某物时
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag =="Distructible")
        {
            Debug.Log("FireBall命中可破坏物体");
            Destroy(collision.gameObject);
            BulletDestroy();
        }
        else if(collision.tag == "Lava")
        {
            Lava lava= collision.gameObject.GetComponent<Lava>();
            lava.Hit();
            BulletDestroy();
        }
        else if(collision.tag == "Default")
        {
            BulletDestroy();
        }
    }

    private void BulletDestroy()
    {
        // 销毁子弹
        Destroy(gameObject);
    }

}
