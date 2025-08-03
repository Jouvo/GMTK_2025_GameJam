using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ParticleSystem explosionParticles; // 拖入粒子Prefab
    public AudioClip clip;

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
        else if(collision.tag == "Untagged"|| collision.tag == "Ice")
        {
            BulletDestroy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void BulletDestroy()
    {
        // 实例化粒子并播放
        ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        particles.Play();
        // 播放音效
        SoundPlayer.Instance.PlaySounds(clip);
        // 销毁子弹
        Destroy(gameObject);
    }

}
