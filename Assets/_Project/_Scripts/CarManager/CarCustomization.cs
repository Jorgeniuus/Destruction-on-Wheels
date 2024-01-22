using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.Character
{
    using SO;

    public class CarCustomization : MonoBehaviour
    {
        [SerializeField] private CarsSO car;
        void Start()
        {

        }

        void Update()
        {

        }

        public void SettingAttributesCar(Color _carColor, MeshFilter _carBullBars, MeshFilter _carHeadLight, MeshFilter[] _carTires, MeshFilter[] _carWeapons)
        {
            //carColorsTextures.GetComponent<Renderer>().sharedMaterial.color = _carColor;
            //carBullBars.GetComponent<MeshFilter>().sharedMesh = _carBullBars.sharedMesh;
            //carHeadLight.GetComponent<MeshFilter>().sharedMesh = _carHeadLight.sharedMesh;

            //for (int i = 0; i < carTires.Length; i++)
            //{
            //    carTires[i].GetComponent<MeshFilter>().sharedMesh = _carTires[i].sharedMesh;
            //}
            //for (int i = 0; i < carWeapons.Length; i++)
            //{
            //    carWeapons[i].GetComponent<MeshFilter>().sharedMesh = _carWeapons[i].sharedMesh;
            //}
        }

        //private void TESTEDECUSTOMIZACAO()
        //{
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {
        //        CarInstantiated.GetComponent<CarPartsManagement>().SettingAttributesCar(color[0].color, bullbar[0].carBullBar, headlight[0].carHeadlight, tires[0].carTires, gun[0].carGun);
        //        //CarInstantiated.GetComponent<Renderer>().material.color = color[0].color;
        //    }
        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        CarInstantiated.GetComponent<CarPartsManagement>().SettingAttributesCar(color[1].color, bullbar[1].carBullBar, headlight[1].carHeadlight, tires[1].carTires, gun[1].carGun);
        //        //CarInstantiated.GetComponent<Renderer>().material.color = color[1].color;
        //    }
        //    if (Input.GetKeyDown(KeyCode.H))
        //    {
        //        CarInstantiated.GetComponent<CarPartsManagement>().SettingAttributesCar(color[2].color, bullbar[2].carBullBar, headlight[2].carHeadlight, tires[2].carTires, gun[2].carGun);
        //        //CarInstantiated.GetComponent<Renderer>().material.color = color[2].color;
        //    }
        //    if (Input.GetKeyDown(KeyCode.J))
        //    {
        //        CarInstantiated.GetComponent<CarPartsManagement>().SettingAttributesCar(color[3].color, bullbar[3].carBullBar, headlight[3].carHeadlight, tires[2].carTires, gun[2].carGun);
        //        //CarInstantiated.GetComponent<Renderer>().material.color = color[3].color;
        //    }
        //}
    }
}