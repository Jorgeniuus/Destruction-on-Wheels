using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DW.Menu
{
    using InputCharacter;
    using SO;

    public class SpawnerCarMenu : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CarsSO car;

        private void OnEnable()
        {
            CarMovement.OnBrakingCar?.Invoke(true);
        }

        private void Awake()
        {
            Instantiate(car.car, spawnPoint.position, spawnPoint.rotation);
        }
    }
}