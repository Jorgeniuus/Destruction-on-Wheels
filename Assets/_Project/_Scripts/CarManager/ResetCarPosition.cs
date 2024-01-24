using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.Character
{
    public class ResetCarPosition : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;

        private void Update()
        {
            InputResetPosition();
        }
        private void InputResetPosition()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetPosition();
            }
        }
        private void ResetPosition()
        {
            CarGenerateManager.Instance.CarInstantiated.transform.position = spawnPoint.position;
            CarGenerateManager.Instance.CarInstantiated.transform.rotation = spawnPoint.rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ResetPosition();
            }
        }
    }
}