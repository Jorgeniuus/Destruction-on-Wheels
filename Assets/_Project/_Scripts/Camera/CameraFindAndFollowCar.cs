using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFindAndFollowCar : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        CameraFollowAndLookAt();
    }
    private void CameraFollowAndLookAt()
    {
        Transform targetFollow = CarGenerateManager.Instance.CarInstantiated.GetComponent<CarPartsManagement>().targetCarFollow;
        _virtualCamera.Follow = targetFollow;
        _virtualCamera.LookAt = targetFollow;
    }
}
