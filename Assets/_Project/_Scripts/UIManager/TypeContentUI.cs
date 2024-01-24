using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace DW.UI
{
    using SO;
    using System.Collections.Generic;

    public class TypeContentUI : MonoBehaviour
    {
        public static Action<string> OnUpdateListTypeButton;
        public enum TypeContentSelected { Painting, Headlight, Tires, Bullbars, Guns }
        public TypeContentSelected typeContentSelected;

        public Button buttonSelectTypeContent;

        [SerializeField] private Contents contents;
        [SerializeField] private TMP_Text typeName;
        [SerializeField] private Transform contentConteiner;
        [SerializeField] private GameObject contentObjectToEquip;
        
        private List<GameObject> _contentName;
        private string myFisrtTypeEnum = "Painting";

        private void OnEnable() => OnUpdateListTypeButton += InicializeTypeContent;
        private void OnDisable() => OnUpdateListTypeButton -= InicializeTypeContent;

        private void Start()
        {
            _contentName = new List<GameObject>();
            buttonSelectTypeContent.onClick.AddListener(() => InicializeTypeContent(typeContentSelected.ToString()));
            InicializeTypeContent(myFisrtTypeEnum);
        }

        public void InicializeTypeContent(string meyEnumName)
        {
            if (meyEnumName == TypeContentSelected.Painting.ToString())
            {
                for (int i = 0; i < contents.painting.Length; i++)
                {
                    GameObject content = Instantiate(contentObjectToEquip, contentConteiner);
                    content.GetComponent<ContentUI>().FromWhatEnumAMI(TypeContentSelected.Painting.ToString());
                    content.GetComponent<ContentUI>().InicializeContent(contents.painting[i], contents.painting[i].color, contents.painting[i].name, contents.painting[i].indexToSelectCustom, contents.painting[i].value, contents.painting[i].equiped, contents.painting[i].resaleAuthorization, contents.painting[i].locked);
                    _contentName.Add(content);                   
                }
            }
            if (meyEnumName == TypeContentSelected.Headlight.ToString())
            {
                for (int i = 0; i < contents.headLight.Length; i++)
                {
                    GameObject content = Instantiate(contentObjectToEquip, contentConteiner);
                    content.GetComponent<ContentUI>().FromWhatEnumAMI(TypeContentSelected.Headlight.ToString());
                    content.GetComponent<ContentUI>().InicializeContent(contents.headLight[i], contents.headLight[i].image, contents.headLight[i].name, contents.headLight[i].indexToSelectCustom, contents.headLight[i].value, contents.headLight[i].equiped, contents.headLight[i].resaleAuthorization, contents.headLight[i].locked);
                    _contentName.Add(content);
                }
            }
            if (meyEnumName == TypeContentSelected.Tires.ToString())
            {
                for (int i = 0; i < contents.tires.Length; i++)
                {
                    GameObject content = Instantiate(contentObjectToEquip, contentConteiner);
                    content.GetComponent<ContentUI>().FromWhatEnumAMI(TypeContentSelected.Tires.ToString());
                    content.GetComponent<ContentUI>().InicializeContent(contents.tires[i], contents.tires[i].image, contents.tires[i].name, contents.tires[i].indexToSelectCustom, contents.tires[i].value, contents.tires[i].equiped, contents.tires[i].resaleAuthorization, contents.tires[i].locked);
                    _contentName.Add(content);
                }
            }
            if (meyEnumName == TypeContentSelected.Bullbars.ToString())
            {
                for (int i = 0; i < contents.bullBars.Length; i++)
                {
                    GameObject content = Instantiate(contentObjectToEquip, contentConteiner);
                    content.GetComponent<ContentUI>().FromWhatEnumAMI(TypeContentSelected.Bullbars.ToString());
                    content.GetComponent<ContentUI>().InicializeContent(contents.bullBars[i], contents.bullBars[i].image, contents.bullBars[i].name, contents.bullBars[i].indexToSelectCustom, contents.bullBars[i].value, contents.bullBars[i].equiped, contents.bullBars[i].resaleAuthorization, contents.bullBars[i].locked);
                    _contentName.Add(content);
                }
            }
            if (meyEnumName == TypeContentSelected.Guns.ToString())
            {
                for (int i = 0; i < contents.guns.Length; i++)
                {
                    GameObject content = Instantiate(contentObjectToEquip, contentConteiner);
                    content.GetComponent<ContentUI>().FromWhatEnumAMI(TypeContentSelected.Guns.ToString());
                    content.GetComponent<ContentUI>().InicializeContent(contents.guns[i], contents.guns[i].image, contents.guns[i].name, contents.guns[i].indexToSelectCustom, contents.guns[i].value, contents.guns[i].equiped, contents.guns[i].resaleAuthorization, contents.guns[i].locked);
                    _contentName.Add(content);
                }
            }
            UpdateListContents(_contentName);
        }   

        private void UpdateListContents(List<GameObject> content)
        {
            ListObjectsShopManager.OnFillOutList?.Invoke(content);
        }

    }
    [Serializable]
    public struct Contents
    {
        public ColorTexturersSO[] painting;
        public HeadlightSO[] headLight;
        public TiresSO[] tires;
        public BullbarSO[] bullBars;
        public WeaponsSO[] guns;
    }
}