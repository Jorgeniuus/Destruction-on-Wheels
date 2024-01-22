using UnityEngine;
using System;

namespace DW.Cash
{
    using SO;
    using Save;
    using Cash;
    using Character;

    public class GarageManager : MonoBehaviour
    {
        public static Action OnSecelectItem; //pensando como vou usar para o UI da garagem
        public static GarageManager Instance { get; private set; }
        public GameObject CarInstantiated { get; private set; }

        [SerializeField] private CarsSO car;

        [SerializeField] private ScriptableObject[] CustomCarParts;

        [SerializeField] private ColorTexturersSO[] color;
        [SerializeField] private TiresSO[] tires;
        [SerializeField] private BullbarSO[] bullbar;
        [SerializeField] private HeadlightSO[] headlight;
        [SerializeField] private WeaponsSO[] gun;

        [SerializeField] private Transform spawnPoint;

        private void Awake()
        {
            Instance = this;
            SpawningCar();
        }

        private void Start()
        {
            SaveOrLoad.LoadData();
        }
        private void Update()
        {
            ClickItem();
            SellItem();
        }

        private void SpawningCar()
        {
            //CarInstantiated = Instantiate(car.car, spawnPoint.position, Quaternion.identity); //ATIVAAR QUANDO TIVER A GARAGEM
        }

        private void UnlockItem()
        {
            bool hasCash = CoinsManager.RequestCoins(gun[2].value);

            if (hasCash)
            {
                SaveOrLoad.data.getGunLocked[2] = false;
                gun[2].locked = SaveOrLoad.data.getGunLocked[2];

                SaveOrLoad.SaveData();
                print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[2] + "-" + SaveOrLoad.data.coins);
                print("Item Comprado");
            }
        }

        private void EquipItem()
        {
            SaveOrLoad.data.gunSelected = 2;
            SaveOrLoad.SaveData();

            CarGenerateManager.Instance.CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

            print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[2] + "-" + SaveOrLoad.data.coins);
            print("Item Equipado");
        }

        public void ClickItem()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (gun[2].locked)
                {
                    UnlockItem();
                    return;
                }
                else EquipItem();
            }

            // =============== TESTTES ===============

            if (Input.GetKeyDown(KeyCode.M)) 
            {
                SaveOrLoad.LoadData();
                SaveOrLoad.data.coins = 5000;
                SaveOrLoad.data.getGunLocked[2] = true;
                gun[2].locked = SaveOrLoad.data.getGunLocked[2];
                SaveOrLoad.data.gunSelected = 0;
                CarGenerateManager.Instance.CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);
                print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[2] + "-" + SaveOrLoad.data.coins);

                SaveOrLoad.SaveData();

                print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[2] + "-" + SaveOrLoad.data.coins);
            }
        }
        public void SellItem()
        {

        }
    }
}