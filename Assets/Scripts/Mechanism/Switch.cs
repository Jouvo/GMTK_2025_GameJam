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

    // 当玩家接触时，切换状态
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StateMgr.Instance.ToggleState();
            // 播放音效
            SoundPlayer.Instance.PlaySounds(clip);
            Debug.Log("切换状态："+ StateMgr.Instance._currentState);
        }
    }
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // 注册状态切换事件
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // 冰模式
                _spriteRenderer.sprite = iceSprite;
                break;
            case EnvironmentState.Fire: // 火模式
                _spriteRenderer.sprite = fireSprite;
                break;
        }
    }

    private void OnDestroy()
    {
        // 取消注册避免内存泄漏
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }
}
