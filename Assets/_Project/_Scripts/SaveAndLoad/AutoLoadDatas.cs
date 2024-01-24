using UnityEngine;
using System;

namespace DW.Save
{
    using SO;

    public class AutoLoadDatas : MonoBehaviour
    {
        public static Action<Datas> OnAutoLoad;

        [SerializeField] private ColorTexturersSO[] color;
        [SerializeField] private TiresSO[] tires;
        [SerializeField] private BullbarSO[] bullbar;
        [SerializeField] private HeadlightSO[] headlight;
        [SerializeField] private WeaponsSO[] gun;

        private void OnEnable() => OnAutoLoad += AutoLoadingDatas;
        private void OnDisable() => OnAutoLoad -= AutoLoadingDatas;

        private void Start()
        {
            SaveOrLoad.LoadData();
            AutoLoadingDatas(SaveOrLoad.data);
        }

        public void AutoLoadingDatas(Datas data)
        {
            print("Chamou Auto Load do Scriptable: "+ headlight[3].locked);
            print("Chamou Auto Load do Save: " + data.getHeadlightLocked[3]);

            for (int i = 0; i < color.Length ; i++)
            {
                color[i].equiped = data.verifyPaintingEquiped[i];
                color[i].locked = data.getPaintingLocked[i];
            }
            for (int i = 0; i < tires.Length; i++)
            {
                tires[i].equiped = data.verifyTiresEquiped[i];
                tires[i].locked = data.getTiresLocked[i];
            }
            for (int i = 0; i < bullbar.Length; i++)
            {
                bullbar[i].equiped = data.verifyBullbarEquiped[i];
                bullbar[i].locked = data.getBullbarLocked[i];
            }
            for (int i = 0; i < headlight.Length; i++)
            {
                headlight[i].equiped = data.verifyHeadlightEquiped[i];
                headlight[i].locked = data.getHeadlightLocked[i];
            }
            for (int i = 0; i < gun.Length; i++)
            {
                gun[i].equiped = data.verifyGunEquiped[i];
                gun[i].locked = data.getGunLocked[i];
            }
        }
    }
}