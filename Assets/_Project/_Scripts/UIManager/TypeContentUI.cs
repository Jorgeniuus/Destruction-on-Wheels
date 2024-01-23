using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace DW.UI
{
    public class TypeContentUI : MonoBehaviour
    {
        public Button buttonSelectTypeContent;

        [SerializeField] private TMP_Text typeName;

        public void InicializeTypeContent(string typeNameContent, int indexTypeContent)
        {
            this.typeName.text = typeNameContent;

            buttonSelectTypeContent.onClick.AddListener(() => SelectTypeContent(indexTypeContent));
        }

        public void SelectTypeContent(int indexTypeContent)
        {
            GarageManagerUI.OnSelectTypeContent?.Invoke(indexTypeContent);
        }
    }
}