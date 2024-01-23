using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DW.UI
{
    public class ContentUI : MonoBehaviour
    {
        [SerializeField] private Button _buttonBuyEquip;
        [SerializeField] private Button _buttonSell;

        [SerializeField] private Image imageContent;
        [SerializeField] private GameObject imageLocked;
        [SerializeField] private TMP_Text textBuyOrEquip;
        [SerializeField] private TMP_Text nameContent;
        [SerializeField] private TMP_Text priceContent;

        private string _buy = "Buy";
        private string _equip = "Equip";

        public void InicializeContent(Sprite imageContent, string nameContent, int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            this.imageContent.sprite = imageContent;
            this.nameContent.text = nameContent;
            this.priceContent.text = "$" + priceContent.ToString();
            imageLocked.SetActive(locked);

            ManageBoolsValues(priceContent, equiped, authotizedSell, locked);
        }
        public void InicializeContent(Color color, string nameContent, int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            this.imageContent.color = color;
            this.nameContent.text = nameContent;
            this.priceContent.text = "$" + priceContent.ToString();
            imageLocked.SetActive(locked);

            ManageBoolsValues(priceContent, equiped, authotizedSell, locked);
        }

        private void ManageBoolsValues(int priceContent, bool equiped, bool authotizedSell, bool locked)
        {
            _buttonBuyEquip.interactable = !equiped;

            if (locked) textBuyOrEquip.text = _buy;
            else textBuyOrEquip.text = _equip;

            if(priceContent > 0 && !locked && !equiped) _buttonSell.interactable = !authotizedSell;
        }
    }
}