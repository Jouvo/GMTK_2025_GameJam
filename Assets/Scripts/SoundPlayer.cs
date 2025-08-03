using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 标记为不销毁
        }
        else
        {
            Destroy(gameObject); // 确保唯一性
        }
    }

    public void PlaySounds(AudioClip clip)
    {
        StartCoroutine(PlayAndDestroy(clip, transform.position));
    }

    IEnumerator PlayAndDestroy(AudioClip clip, Vector3 position)
    {
        GameObject tempObj = new GameObject("TempAudio");
        AudioSource tempSource = tempObj.AddComponent<AudioSource>();
        tempSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Destroy(tempObj);
    }

}
