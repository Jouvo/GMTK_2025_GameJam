using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // �л�����Ŀ��
    public void ChangeFollowTarget(Transform newTarget)
    {
        virtualCamera.Follow = newTarget; // �޸ĸ���λ��
        //virtualCamera.LookAt = newTarget; // �޸�ע��Ŀ��
    }
}
