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
        // ע��״̬�л��¼�
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
        // ��⵱ǰ����״̬���жϵ�ǰΪ��ʯ/�ҽ�״̬
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
            case EnvironmentState.Ice:  // ��ģʽ����Ϊ��ʯ
                _renderer.sprite = iceSprite;
                _collider.enabled = true;
                isRock = true;
                break;
            case EnvironmentState.Fire: // ��ģʽ������ҽ�
                _renderer.sprite = fireSprite;
                _collider.enabled = true;
                isRock = false;
                break;
        }
    }

    private void OnDestroy()
    {
        // ȡ��ע������ڴ�й©
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }

    // ��⵽��������ҽ������������߼�
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

    // ������ʱ������Ƿ�Ϊ��ʯ״̬
    public void Hit()
    {
        if(isRock&&canDestory)
        {
            _collider.enabled = false;
            _renderer.sprite = null;
        }
    }

}
