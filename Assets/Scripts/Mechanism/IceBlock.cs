using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateMgr;

public class IceBlock : MonoBehaviour
{
    public Sprite iceSprite;
    public Sprite fireSprite;
    private SpriteRenderer _renderer;
    [SerializeField] private Collider2D _collider;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        // 注册状态切换事件
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // 冰模式
                _renderer.sprite = iceSprite;
                _collider.enabled= true;
                break;
            case EnvironmentState.Fire: // 火模式
                _renderer.sprite = fireSprite;
                _collider.enabled = false;
                break;
        }
    }

    private void OnDestroy()
    {
        // 取消注册避免内存泄漏
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }
}
