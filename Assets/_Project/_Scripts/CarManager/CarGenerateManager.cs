using UnityEngine;

namespace DW.Character
{
    using SO;
    using Camera;

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

        private void Start() => CallingActionTargetCamera();

        private void CallingActionTargetCamera()
        {
            Transform targetFollow = CarInstantiated.GetComponent<CarPartsManagement>().targetCarFollow;
            CameraFindAndFollowCar.OnTargetFollowAndLookAt?.Invoke(targetFollow);
        }
        private void SpawningCar()
        {
            CarInstantiated = Instantiate(car.car, spawnPoint.position, Quaternion.identity);
        }
    }
}