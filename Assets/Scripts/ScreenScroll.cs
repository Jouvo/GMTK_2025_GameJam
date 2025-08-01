using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScroll : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(1 * speed, 0);
        rb.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
