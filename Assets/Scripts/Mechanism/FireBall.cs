using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    // �������ĳ��ʱ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag =="Distructible")
        {
            Debug.Log("FireBall���п��ƻ�����");
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
        // �����ӵ�
        Destroy(gameObject);
    }

}
