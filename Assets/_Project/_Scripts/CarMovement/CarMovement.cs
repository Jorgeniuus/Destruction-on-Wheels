using UnityEngine;
using System;

namespace DW.InputCharacter
{
    public class CarMovement : MonoBehaviour
    {
        public static Action<bool> OnBrakingCar;

        [Header("Vehicle Settings")]
        [SerializeField] private float motorForce;
        [SerializeField] private float brakeForce;
        [SerializeField] private float maxSteerAngle;

        [Header("Wheels Settings")]
        [SerializeField] private WheelCollider[] frontWheelCollider;
        [SerializeField] private WheelCollider[] rearWheelCollider;
        [SerializeField] private Transform[] frontWheelTransform;
        [SerializeField] private Transform[] rearWheelTransform;

        private bool _isOnGaragebraking = false;
        private bool _isBreaking;
        private float _horizontal;
        private float _vertical;

        private void OnEnable() => OnBrakingCar += HandBrakeGarage;
        private void OnDisable() => OnBrakingCar -= HandBrakeGarage;

        private void Update()
        {
            InputMovement();
        }

        private void FixedUpdate()
        {
            MotorManager();
            SteeringManager();
            WheelsUpdate();
        }

        private void InputMovement()
        {
            if (_isOnGaragebraking) return;

            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            _isBreaking = Input.GetKey(KeyCode.Space);
        }
        private void MotorManager()
        {
            foreach (WheelCollider wheels in rearWheelCollider) wheels.motorTorque = _vertical * motorForce;
            foreach (WheelCollider wheels in frontWheelCollider) wheels.motorTorque = _vertical * motorForce;

            float currentBraking = _isBreaking ? brakeForce : 0f;
            BrakingManager(currentBraking);
        }
        public void HandBrakeGarage(bool handBrake)
        {
            _isOnGaragebraking = handBrake;
            if (handBrake) BrakingManager(brakeForce * 10);
        }
        private void BrakingManager(float currentBreaking)
        {
            for (int i = 0; i < rearWheelCollider.Length; i++)
            {
                rearWheelCollider[i].brakeTorque = currentBreaking;
                frontWheelCollider[i].brakeTorque = currentBreaking;
            }
        }

        private void SteeringManager()
        {
            foreach (WheelCollider wheels in frontWheelCollider) wheels.steerAngle = _horizontal * maxSteerAngle;
        }

        private void WheelsUpdate()
        {
            for (int i = 0; i < frontWheelCollider.Length; i++)
            {
                WheelsTransformUpdate(frontWheelCollider[i], frontWheelTransform[i]);
                WheelsTransformUpdate(rearWheelCollider[i], rearWheelTransform[i]);
            }
        }
        private void WheelsTransformUpdate(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 position;
            Quaternion rotation;

            wheelCollider.GetWorldPose(out position, out rotation);
            wheelTransform.rotation = rotation;
        }
    }
}