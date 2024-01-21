using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPartsManagement : MonoBehaviour
{
    public Transform targetCarFollow;

    [SerializeField] private Renderer carColorsTextures;
    [SerializeField] private Renderer carBullBars;
    [SerializeField] private Renderer carHeadLight;
    [SerializeField] private Renderer carExhaust;
    [SerializeField] private Renderer[] carTires;
    [SerializeField] private Renderer[] carWeapons;

    public void SettingAttributesCar(Color _carColor)
    {
        carColorsTextures.GetComponent<Renderer>().material.color = _carColor;
    }

    public void SettingAttributesCar(Color _carColor, Renderer _carBullBars, Renderer _carHeadLight,
                                    Renderer _carExhaust, Renderer[] _carTires, Renderer[] _carWeapons)
    {
        carColorsTextures.GetComponent<Renderer>().material.color = _carColor;
        //carBullBars
        //carHeadLight;
        //carExhaust;
        //carTires;
        //carWeapons;
    }
}
