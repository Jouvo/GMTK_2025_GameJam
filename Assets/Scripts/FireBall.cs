using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �������ĳ��ʱ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("FireBall��������");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
        {

        }
        else
        {

        }

        // �����ӵ�
        Destroy(gameObject);

    }

}
