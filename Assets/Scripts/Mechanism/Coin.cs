using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float flySpeed = 5f; // ����UI���ٶ�

    private GameMgr GameMgr;

    private void Start()
    {
        GameMgr = GameMgr.Instance;
    }

    // ������������ʱ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
            GameMgr.Instance.AddCoin(1);    // GameMgr��ӽ��
        }
    }

    public void FlyToUI(Vector3 targetPos)
    {
        StartCoroutine(MoveToTarget(targetPos));
    }

    IEnumerator MoveToTarget(Vector3 targetPos)
    {
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, flySpeed * Time.deltaTime);
            yield return null;
        }
        //yield return new WaitForSeconds(0.1f);

        // ������Ч��������Ч����ѡ��

        Destroy(gameObject); // ���������
    }

    public void Collect()
    {
        // ת����Ļ���굽�������꣬�����ƶ�����
        Vector3 TargetPos = GetWorldPositionOfUI();
        TargetPos += new Vector3(4, 0.5f, 0);
        FlyToUI(TargetPos);

    }

    Vector3 GetWorldPositionOfUI()
    {
        RectTransform rect = GameMgr.coinIcon.rectTransform;
        Vector3 screenPos = rect.TransformPoint(rect.rect.center);
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}
