using UnityEngine;
using Cinemachine;
using System;

namespace DW.Camera
{
    public class CameraFindAndFollowCar : MonoBehaviour
    {
        public static Action<Transform> OnTargetFollowAndLookAt;

        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private void OnEnable() => OnTargetFollowAndLookAt += CameraFollowAndLookAt;
        private void OnDisable() => OnTargetFollowAndLookAt -= CameraFollowAndLookAt;
        
        private void CameraFollowAndLookAt(Transform targetFollow)
        {
            _virtualCamera.Follow = targetFollow;
            _virtualCamera.LookAt = targetFollow;
        }
    }
}