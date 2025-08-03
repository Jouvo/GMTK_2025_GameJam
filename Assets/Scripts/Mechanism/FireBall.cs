using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ParticleSystem explosionParticles; // ��������Prefab

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
        else if(collision.tag == "Untagged")
        {
            Debug.Log("FireBall����!!!");
            BulletDestroy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void BulletDestroy()
    {
        // ʵ�������Ӳ�����
        ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        particles.Play();
        // �����ӵ�
        Destroy(gameObject);
    }

}
