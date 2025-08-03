using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMask : MonoBehaviour
{
    public SpriteRenderer spRenderer;
    public float Duration = 0.5f;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        spRenderer= GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        // 播放音效
        SoundPlayer.Instance.PlaySounds(clip);
        StartCoroutine(FadeOut());
    }

    // 黑幕淡出
    public IEnumerator FadeOut()
    {
        float counter = 0f;
        float startAlpha = 1f; // 淡出时起始透明度为不透明
        float endAlpha = 0f;   // 淡出时结束透明度为透明
        //Debug.Log("准备淡出");
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, counter / Duration);
            spRenderer.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        Destroy(this.gameObject);
    }

}
