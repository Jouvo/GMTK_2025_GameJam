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
        // ������Ч
        SoundPlayer.Instance.PlaySounds(clip);
        StartCoroutine(FadeOut());
    }

    // ��Ļ����
    public IEnumerator FadeOut()
    {
        float counter = 0f;
        float startAlpha = 1f; // ����ʱ��ʼ͸����Ϊ��͸��
        float endAlpha = 0f;   // ����ʱ����͸����Ϊ͸��
        //Debug.Log("׼������");
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
