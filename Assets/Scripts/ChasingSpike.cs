using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingSpike : MonoBehaviour
{
    public float speed=5;
    Rigidbody2D rb;
    VCam cam;
    SpriteRenderer spriteRenderer;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<VCam>();
        rb= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // ������Ļ���꣺X=0������ࣩ��Y=��Ļ�߶�һ�루���У�
        Vector3 screenPos = new Vector3(0, Screen.height / 2, 10f);
        // ת��Ϊ�������꣨��ָ�����ֵ��
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        // ����ͼƬ��С����ƫ��
        Vector2 worldSize = spriteRenderer.bounds.size;
        offset = worldSize.x / 2;

        worldPos += new Vector3(offset, 0, 0);
        transform.position = worldPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if(player != null)
            {
                player.GetComponent<PlayerMovement>().Die();
            }
        }
    }

}
