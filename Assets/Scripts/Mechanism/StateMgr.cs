using UnityEngine;
using System;

public class StateMgr : MonoBehaviour
{
    public static StateMgr Instance;

    public enum EnvironmentState { Ice, Fire }
    public EnvironmentState _currentState = EnvironmentState.Ice;

    // �����¼�ί��
    public event Action<EnvironmentState> OnStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �糡���־û�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �л�״̬�������¼�
    public void ToggleState()
    {
        _currentState = _currentState == EnvironmentState.Ice ? EnvironmentState.Fire : EnvironmentState.Ice;
        OnStateChanged?.Invoke(_currentState); // ֪ͨ���м�����
    }
}