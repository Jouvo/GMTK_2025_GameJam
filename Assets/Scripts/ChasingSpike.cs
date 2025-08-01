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

    // 根据当前镜头位置重置于最左侧
    public void ResetPos()
    {
        // 计算屏幕坐标：X=0（最左侧），Y=屏幕高度一半（居中）
        Vector3 screenPos = new Vector3(0, Screen.height / 2, 10f);
        // 转换为世界坐标（需指定深度值）
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        // 根据图片大小计算偏移
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
