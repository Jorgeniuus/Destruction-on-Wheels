using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DW.UI
{
    using Cash;

    public class ContentUI : MonoBehaviour
    {            
        [SerializeField] private Button _buttonBuyEquip;
        [SerializeField] private Button _buttonSell;

        [SerializeField] private Image imageContent;
        [SerializeField] private GameObject imageLocked;
        [SerializeField] private TMP_Text textBuyOrEquip;
        [SerializeField] private TMP_Text nameContent;
        [SerializeField] private TMP_Text priceContent;

        private ScriptableObject _scriptableObject;

        private string _buyText = "Buy";
        private string _equipText = "Equip";
        private string _equipedText = "Equiped";

        private int _priceContent;
        private int _indexContent;

        private bool _locked;
        private bool _authorized;
        private bool _equiped;

        public void InicializeContent(ScriptableObject scriptableObject, Sprite imageContent, string nameContent, int indexContent, int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            this.imageContent.sprite = imageContent;
            this.nameContent.text = nameContent;
            this.priceContent.text = "$" + priceContent.ToString();
            imageLocked.SetActive(locked);
            _locked = locked;
            _authorized = authotizedSell;
            _equiped = equiped; 

            _priceContent = priceContent;
            _indexContent = indexContent;

            _scriptableObject = scriptableObject;

            ManageBoolsValues(priceContent, equiped, authotizedSell, locked);
        }
        public void InicializeContent(ScriptableObject scriptableObject, Color color, string nameContent, int indexContent, int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            this.imageContent.color = color;
            this.nameContent.text = nameContent;
            this.priceContent.text = "$" + priceContent.ToString();
            imageLocked.SetActive(locked);
            _locked = locked;
            _authorized = authotizedSell;
            _equiped = equiped;

            _priceContent = priceContent;
            _indexContent = indexContent;

            _scriptableObject = scriptableObject;

            ManageBoolsValues(priceContent, equiped, authotizedSell, locked);
        }

        private void ManageBoolsValues(int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            _buttonBuyEquip.interactable = !equiped;

            if (locked) textBuyOrEquip.text = _buyText;
            else if(equiped) textBuyOrEquip.text = _equipedText;
            else textBuyOrEquip.text = _equipText;

            

            if (priceContent > 0 && locked == false) _buttonSell.interactable = authotizedSell;
            else
            {
                _buttonSell.interactable = false;
                if(priceContent > 0 && _buttonSell.interactable == false) _buttonBuyEquip.interactable = true;
            }
        }

        public void BuyOrEquipItem()
        {
            GarageManager.OnButtonBuyEquip?.Invoke(_scriptableObject, _locked, _indexContent, _priceContent);
            TypeContentUI.OnUpdateListTypeButton?.Invoke();
        }

        public void SellItem()
        {
            if (_equiped == false)
                GarageManager.OnButtonSellItem?.Invoke(_scriptableObject, _authorized, _indexContent, _priceContent);

            TypeContentUI.OnUpdateListTypeButton?.Invoke();
        }
    }
}