using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.Character
{
    using SO;

    public class CarGenerateManager : MonoBehaviour
    {
        public static CarGenerateManager Instance { get; private set; }
        public GameObject CarInstantiated { get; set; }
        [SerializeField] private CarsSO car;
        [SerializeField] private Transform spawnPoint;

        private void Awake()
        {
            Instance = this;
            SpawningCar();
        }
        private void SpawningCar()
        {
            CarInstantiated = Instantiate(car.car, spawnPoint.position, Quaternion.identity);
        }
    }
}