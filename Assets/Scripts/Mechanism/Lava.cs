using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateMgr;

public class Lava : MonoBehaviour
{
    public Sprite iceSprite;
    public Sprite fireSprite;
    public bool canDestory=false;

    private bool isRock;
    private Collider2D _collider;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        // 注册状态切换事件
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
        // 检测当前环境状态，判断当前为岩石/岩浆状态
        if(StateMgr.Instance._currentState== EnvironmentState.Ice)
        {
            isRock = true;
            _renderer.sprite = iceSprite;
        }
        else
        {
            isRock = false;
            _renderer.sprite = fireSprite;
        }
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // 冰模式，变为岩石
                _renderer.sprite = iceSprite;
                _collider.enabled = true;
                isRock = true;
                break;
            case EnvironmentState.Fire: // 火模式，变回岩浆
                _renderer.sprite = fireSprite;
                _collider.enabled = true;
                isRock = false;
                break;
        }
    }

    private void OnDestroy()
    {
        // 取消注册避免内存泄漏
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }

    // 检测到玩家碰到岩浆，调用死亡逻辑
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&isRock==false)
        {
            GameObject player = collision.gameObject;
            if (player != null)
            {
                player.GetComponent<PlayerMovement>().Die();
            }
        }
    }

    // 被命中时，检测是否为岩石状态
    public void Hit()
    {
        if(isRock&&canDestory)
        {
            _collider.enabled = false;
            _renderer.sprite = null;
        }
    }

}
