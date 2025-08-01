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

    // 切换跟随目标
    public void ChangeFollowTarget(Transform newTarget)
    {
        virtualCamera.Follow = newTarget; // 修改跟随位置
        //virtualCamera.LookAt = newTarget; // 修改注视目标
    }
}
