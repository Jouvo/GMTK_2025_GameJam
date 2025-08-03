using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float flySpeed = 5f; // 飞向UI的速度

    private GameMgr GameMgr;

    private void Start()
    {
        GameMgr = GameMgr.Instance;
    }

    // 当玩家碰到金币时
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
            GameMgr.Instance.AddCoin(1);    // GameMgr添加金币
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

        // 播放音效或粒子特效（可选）

        Destroy(gameObject); // 到达后销毁
    }

    public void Collect()
    {
        // 转换屏幕坐标到世界坐标，调用移动函数
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
