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
        // ע��״̬�л��¼�
        StateMgr.Instance.OnStateChanged += OnEnvironmentStateChanged;
    }

    private void OnEnvironmentStateChanged(EnvironmentState newState)
    {
        switch (newState)
        {
            case EnvironmentState.Ice:  // ��ģʽ
                _renderer.sprite = iceSprite;
                _collider.enabled= true;
                break;
            case EnvironmentState.Fire: // ��ģʽ
                _renderer.sprite = fireSprite;
                _collider.enabled = false;
                break;
        }
    }

    private void OnDestroy()
    {
        // ȡ��ע������ڴ�й©
        StateMgr.Instance.OnStateChanged -= OnEnvironmentStateChanged;
    }
}
