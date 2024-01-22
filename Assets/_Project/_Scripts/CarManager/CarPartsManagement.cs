using UnityEngine;

namespace DW.Character
{
    using Save;
    using SO;

    public class CarPartsManagement : MonoBehaviour
    {
        public Transform targetCarFollow;

        [SerializeField] private ColorTexturersSO[] color;
        [SerializeField] private TiresSO[] tires;
        [SerializeField] private BullbarSO[] bullbar;
        [SerializeField] private HeadlightSO[] headlight;
        [SerializeField] private WeaponsSO[] gun;

        [SerializeField] private Renderer carColorsTextures;
        [SerializeField] private MeshFilter carBullBars;
        [SerializeField] private MeshFilter carHeadLight;
        [SerializeField] private MeshFilter[] carTires;
        [SerializeField] private MeshFilter[] carWeapons;

        private void Start()
        {
            SaveOrLoad.LoadData();
            SettingCarsAttributes(SaveOrLoad.data);
        }

        public void SettingCarsAttributes(Datas data)
        {
            carColorsTextures.GetComponent<Renderer>().sharedMaterial.color = color[data.paintingSelected].color;
            carBullBars.GetComponent<MeshFilter>().sharedMesh = bullbar[data.bullbarSelected].carBullBar.sharedMesh;
            carHeadLight.GetComponent<MeshFilter>().sharedMesh = headlight[data.headlightSelected].carHeadlight.sharedMesh;

            for (int i = 0; i < carTires.Length; i++)
            {
                carTires[i].GetComponent<MeshFilter>().sharedMesh = tires[data.tiresSelected].carTires[i].sharedMesh;
            }
            for (int i = 0; i < carWeapons.Length; i++)
            {
                carWeapons[i].GetComponent<MeshFilter>().sharedMesh = gun[data.gunSelected].carGun[i].sharedMesh;
            }
        }
    }
}