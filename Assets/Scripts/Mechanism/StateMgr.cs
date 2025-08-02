using UnityEngine;
using System;

public class StateMgr : MonoBehaviour
{
    public static StateMgr Instance;

    public enum EnvironmentState { Ice, Fire }
    public EnvironmentState _currentState = EnvironmentState.Ice;

    // 定义事件委托
    public event Action<EnvironmentState> OnStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 跨场景持久化
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 切换状态并触发事件
    public void ToggleState()
    {
        _currentState = _currentState == EnvironmentState.Ice ? EnvironmentState.Fire : EnvironmentState.Ice;
        OnStateChanged?.Invoke(_currentState); // 通知所有监听者
    }
}