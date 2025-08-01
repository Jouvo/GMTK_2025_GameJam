using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingSpike : MonoBehaviour
{
    public float speed=5;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ResetPos();
        }
    }

    // ���ݵ�ǰ��ͷλ�������������
    public void ResetPos()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().Die();
            }
        }
    }

}
