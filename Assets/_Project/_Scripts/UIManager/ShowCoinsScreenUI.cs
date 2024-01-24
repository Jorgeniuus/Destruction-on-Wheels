using UnityEngine;
using TMPro;
using System;

namespace DW.UI
{
    using Save;

    public class ShowCoinsScreenUI : MonoBehaviour
    {
        public static Action<int> OnChangevalueShowedCoin;

        [SerializeField] private TMP_Text showingCoins;

        private void OnEnable() => OnChangevalueShowedCoin += ShowCoins;
        private void OnDisable() => OnChangevalueShowedCoin -= ShowCoins;

        private void Start()
        {
            SaveOrLoad.LoadData();
            ShowCoins(SaveOrLoad.data.coins);
        }
        public void ShowCoins(int coins)
        {
            showingCoins.text = $" ${coins}";
        }
    }
}