using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBall;
    public float fireSpeed = 15;
    public float fireCoolTime = 0.5f;   // ������

    public bool canFire = true;

    private bool isLearnFire = true;
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isLearnFire)
        {
            // �������Ƿ���CD��
            nextFireTime += Time.deltaTime;
            if (nextFireTime >= fireCoolTime)
            {
                nextFireTime = 0f;
                canFire = true;
            }

            // ����ҵ���������������ʱ
            if (Input.GetMouseButtonDown(0) && canFire == true)
            {
                canFire = false;
                Launch(fireBall, fireSpeed);
            }
        }
        
        
    }

    public void Launch(GameObject FirePrefab,float speed)
    {
        GameObject Fire=Instantiate(FirePrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb=Fire.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * speed;
    }

}
