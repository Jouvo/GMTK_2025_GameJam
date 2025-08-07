using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{
    public int crystalID; // 水晶唯一标识，对应UI槽位
    public float flySpeed = 5f; // 飞向UI的速度
    public AudioClip clip;

    private GameMgr gameMgr;

    private void Start()
    {
        gameMgr = GameMgr.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 播放音效
            SoundPlayer.Instance.PlaySounds(clip);
            CollectCrystal();
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

        

        // 点亮对应槽位
        gameMgr.crystalSlots[crystalID].color = new Color(1, 1, 1, 1);
        Destroy(gameObject); // 到达后销毁
    }

    public void CollectCrystal()
    {
        Debug.Log("收集水晶");
        gameMgr.crystalID.Add(crystalID);
        // 转换屏幕坐标到世界坐标，调用水晶移动函数
        Vector3 TargetPos = GetWorldPositionOfUI(crystalID);
        TargetPos += new Vector3(4, 0.5f, 0);
        FlyToUI(TargetPos);

    }

    Vector3 GetWorldPositionOfUI(int crystalID)
    {
        RectTransform rect = gameMgr.crystalSlots[crystalID].rectTransform;
        Vector3 screenPos = rect.TransformPoint(rect.rect.center);
        return Camera.main.ScreenToWorldPoint(screenPos);
    }


}