using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ButtonCtrl : MonoBehaviour
{

    public string startSceneName; // 在Inspector窗口中设置开始场景的名称
    public AudioClip clickSound; // 攻击音效
    public float SceneLoadDelayTime = 0.6f;

    public void StartGame()
    {

        // 等待一段时间后加载新游戏场景
        StartCoroutine(LoadSceneWithDelay(SceneLoadDelayTime)); // 1.0秒的延迟
    }

    private IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 在等待一段时间后加载新游戏场景
        SceneManager.LoadScene(startSceneName);
    }

    public void OpenSettings()
    {
        // 在这里编写打开设置界面的代码
    }

    public void ShowCredits()
    {
        // 在这里编写显示Credit信息的代码
    }

    public void ExitGame()
    {
        Application.Quit(); // 退出游戏应用
    }

    public void PlayClickSound()
    {
        // 获取当前GameObject上的组件AudioSource
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clickSound);
    }
}
