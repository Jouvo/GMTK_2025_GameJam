using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateMgr;

public class Switch : MonoBehaviour
{
    public Sprite iceSprite;
    public Sprite fireSprite;
    public AudioClip clip;
    private SpriteRenderer _spriteRenderer;

    // ����ҽӴ�ʱ���л�״̬
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMgr.Instance.ToggleState();
            // ������Ч
            SoundPlayer.Instance.PlaySounds(clip);
            Debug.Log("�л�״̬��"+ StateMgr.Instance._currentState);
        }
    }
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // ע��״̬�л��¼�
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // ��ģʽ
                _spriteRenderer.sprite = iceSprite;
                break;
            case EnvironmentState.Fire: // ��ģʽ
                _spriteRenderer.sprite = fireSprite;
                break;
        }
    }

    private void OnDestroy()
    {
        // ȡ��ע������ڴ�й©
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }
}
