using UnityEngine;
using System;

namespace DW.Cash
{
    using SO;
    using Save;
    using Character;
    using Camera;
    using InputCharacter;
    using UI;

    public class GarageManager : MonoBehaviour
    {
        public static Action<bool> OnBrakingCar;
        public static Action<ScriptableObject, bool, int, int> OnButtonBuyEquip;
        public static Action<ScriptableObject, bool, int, int> OnButtonSellItem;

        public static GarageManager Instance { get; private set; }

        public GameObject CarInstantiated { get; private set; }

        [SerializeField] private CarsSO car;

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

        private void OnEnable()
        {
            OnButtonBuyEquip += ClickItem;
            OnButtonSellItem += SellItem;
        }
        private void OnDisable()
        {
            OnButtonBuyEquip -= ClickItem;
            OnButtonSellItem -= SellItem;
        }

        private void Start()
        {
            SaveOrLoad.LoadData();
            CallingActions();
        }
        private void Update()
        {
        }
        private void CallingActions()
        {
            Transform targetFollow = CarInstantiated.GetComponent<CarPartsManagement>().targetCarFollow;
            CameraFindAndFollowCar.OnTargetFollowAndLookAt?.Invoke(targetFollow);

            CarMovement.OnBrakingCar?.Invoke(true);
        }
        private void SpawningCar()
        {
            CarInstantiated = Instantiate(car.car, spawnPoint.position, spawnPoint.rotation); 
        }

        private void CallActions()
        {
            ShowCoinsScreenUI.OnChangevalueShowedCoin?.Invoke(SaveOrLoad.data.coins);
            AutoLoadDatas.OnAutoLoad?.Invoke(SaveOrLoad.data);
        }
        private void UnlockItem(ScriptableObject scriptable, int itemIndex, int itemValue)
        {
            bool hasCash = CoinsManager.RequestCoins(itemValue);

            if (hasCash)
            {
                if (scriptable is HeadlightSO)
                {
                    SaveOrLoad.data.getHeadlightLocked[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    headlight[itemIndex].locked = SaveOrLoad.data.getHeadlightLocked[itemIndex]; 

                    print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is TiresSO)
                {
                    SaveOrLoad.data.getTiresLocked[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    tires[itemIndex].locked = SaveOrLoad.data.getTiresLocked[itemIndex];

                    print(SaveOrLoad.data.tiresSelected + "-" + SaveOrLoad.data.getTiresLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is BullbarSO)
                {
                    SaveOrLoad.data.getBullbarLocked[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    bullbar[itemIndex].locked = SaveOrLoad.data.getBullbarLocked[itemIndex];

                    print(SaveOrLoad.data.bullbarSelected + "-" + SaveOrLoad.data.getBullbarLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is WeaponsSO)
                {
                    SaveOrLoad.data.getGunLocked[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    gun[itemIndex].locked = SaveOrLoad.data.getGunLocked[itemIndex];

                    print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                CallActions();
            }
        }

        private void EquipItem(ScriptableObject scriptable, int itemIndex)
        {
            if (scriptable is HeadlightSO)
            {
                SaveOrLoad.data.verifyHeadlightEquiped[itemIndex] = true;

                for (int i = 0; i < SaveOrLoad.data.verifyHeadlightEquiped.Length; i++)
                {
                    if(i != itemIndex) SaveOrLoad.data.verifyHeadlightEquiped[i] = false;
                    headlight[i].equiped = false;
                }

                SaveOrLoad.data.headlightSelected = itemIndex;
                SaveOrLoad.SaveData();
                SaveOrLoad.LoadData();

                headlight[itemIndex].equiped = SaveOrLoad.data.verifyHeadlightEquiped[itemIndex];

                CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

                print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                print("Item Equipado");
            }
            if (scriptable is TiresSO)
            {
                SaveOrLoad.data.verifyTiresEquiped[itemIndex] = true;

                for (int i = 0; i < SaveOrLoad.data.verifyTiresEquiped.Length; i++)
                {
                    if (i != itemIndex) SaveOrLoad.data.verifyTiresEquiped[i] = false;
                    tires[i].equiped = false;
                }

                SaveOrLoad.data.tiresSelected = itemIndex;
                SaveOrLoad.SaveData();
                SaveOrLoad.LoadData();

                tires[itemIndex].equiped = SaveOrLoad.data.verifyTiresEquiped[itemIndex];

                CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

                print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                print("Item Equipado");
            }
            if (scriptable is BullbarSO)
            {
                SaveOrLoad.data.verifyBullbarEquiped[itemIndex] = true;

                for (int i = 0; i < SaveOrLoad.data.verifyBullbarEquiped.Length; i++)
                {
                    if (i != itemIndex) SaveOrLoad.data.verifyBullbarEquiped[i] = false;
                    bullbar[i].equiped = false;
                }

                SaveOrLoad.data.bullbarSelected = itemIndex;
                SaveOrLoad.SaveData();
                SaveOrLoad.LoadData();

                bullbar[itemIndex].equiped = SaveOrLoad.data.verifyBullbarEquiped[itemIndex];

                CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

                print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                print("Item Equipado");
            }
            if (scriptable is WeaponsSO)
            {
                SaveOrLoad.data.verifyGunEquiped[itemIndex] = true;

                for (int i = 0; i < SaveOrLoad.data.verifyGunEquiped.Length; i++)
                {
                    if (i != itemIndex) SaveOrLoad.data.verifyGunEquiped[i] = false;
                    gun[i].equiped = false;
                }

                SaveOrLoad.data.gunSelected = itemIndex;
                SaveOrLoad.SaveData();
                SaveOrLoad.LoadData();

                gun[itemIndex].equiped = SaveOrLoad.data.verifyGunEquiped[itemIndex];

                CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

                print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                print("Item Equipado");
            }
            if (scriptable is ColorTexturersSO)
            {
                SaveOrLoad.data.verifyPaintingEquiped[itemIndex] = true;

                for (int i = 0; i < SaveOrLoad.data.verifyPaintingEquiped.Length; i++)
                {
                    if (i != itemIndex) SaveOrLoad.data.verifyPaintingEquiped[i] = false;
                    color[i].equiped = false;
                }

                SaveOrLoad.data.paintingSelected = itemIndex;
                SaveOrLoad.SaveData();
                SaveOrLoad.LoadData();

                color[itemIndex].equiped = SaveOrLoad.data.verifyPaintingEquiped[itemIndex];

                CarInstantiated.GetComponent<CarPartsManagement>().SettingCarsAttributes(SaveOrLoad.data);

                print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                print("Item Equipado");
            }

        }

        public void ClickItem(ScriptableObject scriptable, bool locked, int intemIndex, int itemValue) 
        {
            if (locked)
            {
                UnlockItem(scriptable, intemIndex, itemValue);
                return;
            }
            else EquipItem(scriptable, intemIndex);
        }
        public void SellItem(ScriptableObject scriptable, bool autthotrized, int itemIndex, int itemVValuee)
        {
            bool hasCash = CoinsManager.RequestSale(itemVValuee , autthotrized); 

            if (hasCash)
            {
                if (scriptable is HeadlightSO)
                {
                    SaveOrLoad.data.getHeadlightLocked[itemIndex] = true;
                    SaveOrLoad.data.verifyHeadlightEquiped[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    headlight[itemIndex].locked = SaveOrLoad.data.getHeadlightLocked[itemIndex];
                    headlight[itemIndex].equiped = SaveOrLoad.data.verifyHeadlightEquiped[itemIndex];

                    print(SaveOrLoad.data.headlightSelected + "-" + SaveOrLoad.data.getHeadlightLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is TiresSO)
                {
                    SaveOrLoad.data.getTiresLocked[itemIndex] = true;
                    SaveOrLoad.data.verifyTiresEquiped[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    tires[itemIndex].locked = SaveOrLoad.data.getTiresLocked[itemIndex];
                    headlight[itemIndex].equiped = SaveOrLoad.data.verifyTiresEquiped[itemIndex];

                    print(SaveOrLoad.data.tiresSelected + "-" + SaveOrLoad.data.getTiresLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is BullbarSO)
                {
                    SaveOrLoad.data.getBullbarLocked[itemIndex] = true;
                    SaveOrLoad.data.verifyBullbarEquiped[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    bullbar[itemIndex].locked = SaveOrLoad.data.getBullbarLocked[itemIndex];
                    headlight[itemIndex].equiped = SaveOrLoad.data.verifyBullbarEquiped[itemIndex];

                    print(SaveOrLoad.data.bullbarSelected + "-" + SaveOrLoad.data.getBullbarLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                if (scriptable is WeaponsSO)
                {
                    SaveOrLoad.data.getGunLocked[itemIndex] = true;
                    SaveOrLoad.data.verifyGunEquiped[itemIndex] = false;
                    SaveOrLoad.SaveData();
                    SaveOrLoad.LoadData();

                    gun[itemIndex].locked = SaveOrLoad.data.getGunLocked[itemIndex];
                    headlight[itemIndex].equiped = SaveOrLoad.data.verifyGunEquiped[itemIndex];

                    print(SaveOrLoad.data.gunSelected + "-" + SaveOrLoad.data.getGunLocked[itemIndex] + "-" + SaveOrLoad.data.coins);
                    print("Item Comprado");
                }
                CallActions();
            }
        }
    }
}