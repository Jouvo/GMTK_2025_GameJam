using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{
    public int crystalID; // ˮ��Ψһ��ʶ����ӦUI��λ
    public float flySpeed = 5f; // ����UI���ٶ�
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
            // ������Ч
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

        // ������Ч��������Ч����ѡ��

        

        // ������Ӧ��λ
        gameMgr.crystalSlots[crystalID].color = new Color(1, 1, 1, 1);
        Destroy(gameObject); // ���������
    }

    public void CollectCrystal()
    {
        Debug.Log("�ռ�ˮ��");
        gameMgr.crystalID.Add(crystalID);
        // ת����Ļ���굽�������꣬����ˮ���ƶ�����
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