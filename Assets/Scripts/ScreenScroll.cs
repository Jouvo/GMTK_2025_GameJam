using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScroll : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] private bool canMove = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }

    // 持续往右移动
    private void Move()
    {
        Vector2 movement = new Vector2(1 * speed, 0);
        rb.velocity = movement;
    }

    // 控制移动开始/结束
    public void Switch(bool f)
    {
        if (f)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
