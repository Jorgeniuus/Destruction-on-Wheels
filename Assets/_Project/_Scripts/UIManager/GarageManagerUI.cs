using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DW.UI
{
    using SO;

    public class GarageManagerUI : MonoBehaviour
    {
        public static Action<int> OnSelectTypeContent;

        [SerializeField] private Transform typeContentConteiner;
        [SerializeField] private Transform contentConteiner;
        [SerializeField] private GameObject typeContentObject;
        [SerializeField] private GameObject contentObjectToEquip;

        [SerializeField] private Contents contents;

        private string[] _typeNames = {"Painting", "Headlight", "Tires", "Bullbars", "Guns" };
        private List<int> _indexTypeNames;
        private List<GameObject> _contentName;

        private void OnEnable() => OnSelectTypeContent += DetectIndexContent;
        private void OnDisable() => OnSelectTypeContent -= DetectIndexContent;

        private void Start()
        {
            _indexTypeNames = new List<int>();
            _contentName = new List<GameObject>();

            for (int i = 0; i < _typeNames.Length; i++)
            {
                GameObject typeContentName = Instantiate(typeContentObject, typeContentConteiner);
                typeContentName.GetComponent<TypeContentUI>().InicializeTypeContent(_typeNames[i], i);
                _indexTypeNames.Add(i);
            }

            DetectIndexContent(0);
        }

        private void DetectIndexContent(int indexContent)
        {
            for (int i = 0; i < _indexTypeNames.Count; i++)
            {
                if (indexContent == _indexTypeNames[i]) FillContent(indexContent);
            }
        }
        private void FillContent(int indexContent)
        {
            UpdateListContents();
            if (_contentName.Count > 0) return;
            if (indexContent == 0)
            {
                for (int i = 0; i < contents.painting.Length; i++)
                {
                    _contentName.Add(Instantiate(contentObjectToEquip, contentConteiner));
                    _contentName[i].GetComponent<ContentUI>().InicializeContent(contents.painting[i].color, contents.painting[i].name, contents.painting[i].value, contents.painting[i].equiped, contents.painting[i].resaleAuthorization, contents.painting[i].locked);
                }
            }
            if (indexContent == 1)
            {
                for (int i = 0; i < contents.headLight.Length; i++)
                {
                    _contentName.Add(Instantiate(contentObjectToEquip, contentConteiner));
                    _contentName[i].GetComponent<ContentUI>().InicializeContent(contents.headLight[i].image, contents.headLight[i].name, contents.headLight[i].value, contents.headLight[i].equiped, contents.headLight[i].resaleAuthorization, contents.headLight[i].locked);
                }
            }
            if (indexContent == 2)
            {
                for (int i = 0; i < contents.tires.Length; i++)
                {
                    _contentName.Add(Instantiate(contentObjectToEquip, contentConteiner));
                    _contentName[i].GetComponent<ContentUI>().InicializeContent(contents.tires[i].image, contents.tires[i].name, contents.tires[i].value, contents.tires[i].equiped, contents.tires[i].resaleAuthorization, contents.tires[i].locked);
                }
            }
            if (indexContent == 3)
            {
                for (int i = 0; i < contents.bullBars.Length; i++)
                {
                    _contentName.Add(Instantiate(contentObjectToEquip, contentConteiner));
                    _contentName[i].GetComponent<ContentUI>().InicializeContent(contents.bullBars[i].image, contents.bullBars[i].name, contents.bullBars[i].value, contents.bullBars[i].equiped, contents.bullBars[i].resaleAuthorization, contents.bullBars[i].locked);
                }
            }
            if (indexContent == 4)
            {
                for (int i = 0; i < contents.guns.Length; i++)
                {
                    _contentName.Add(Instantiate(contentObjectToEquip, contentConteiner));
                    _contentName[i].GetComponent<ContentUI>().InicializeContent(contents.guns[i].image, contents.guns[i].name, contents.guns[i].value, contents.guns[i].equiped, contents.guns[i].resaleAuthorization, contents.guns[i].locked);
                }
            }
        }

        private void UpdateListContents()
        {
            if (_contentName.Count > 0)
            {
                for (int i = 0; i < _contentName.Count; i++)
                {
                    Destroy(_contentName[i].gameObject);
                }
                _contentName.Clear();
            }
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