using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ButtonCtrl : MonoBehaviour
{

    public string startSceneName; // ��Inspector���������ÿ�ʼ����������
    public AudioClip clickSound; // ������Ч
    public float SceneLoadDelayTime = 0.6f;

    public void StartGame()
    {

        // �ȴ�һ��ʱ����������Ϸ����
        StartCoroutine(LoadSceneWithDelay(SceneLoadDelayTime)); // 1.0����ӳ�
    }

    private IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // �ڵȴ�һ��ʱ����������Ϸ����
        SceneManager.LoadScene(startSceneName);
    }

    public void OpenSettings()
    {
        // �������д�����ý���Ĵ���
    }

    public void ShowCredits()
    {
        // �������д��ʾCredit��Ϣ�Ĵ���
    }

    public void ExitGame()
    {
        Application.Quit(); // �˳���ϷӦ��
    }

    public void PlayClickSound()
    {
        // ��ȡ��ǰGameObject�ϵ����AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clickSound);
    }
}
