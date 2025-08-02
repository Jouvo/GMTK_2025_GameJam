using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public Vector2 windDirection = Vector2.up; // ���������ϴ���
    public float windForce = 10f; // ������С

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(windDirection * windForce, ForceMode2D.Force);
            }
        }
    }
}
