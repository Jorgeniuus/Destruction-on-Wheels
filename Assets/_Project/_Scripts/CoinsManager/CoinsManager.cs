namespace DW.Cash
{
    using Save;
    using UnityEngine;

    public class CoinsManager
    {
        public static int ShowCoins()
        {
            SaveOrLoad.LoadData();
            return SaveOrLoad.data.coins;
        }
        public static bool RequestCoins(int value)
        {
            int coins = SaveOrLoad.data.coins;
            
            if (coins >= value)
            {
                coins -= value;

                SaveOrLoad.data.coins = coins;
                SaveOrLoad.SaveData();

                return true;
            }
            else return false;
        }

        public static bool RequestSale(int saleValue, bool resaleAuthorized)
        {
            if (resaleAuthorized)
            {
                int coins = saleValue - (30 * saleValue / 100);
                SaveOrLoad.data.coins = coins;
                SaveOrLoad.SaveData();
                return true;
            }
            else return false;
        }
    }
}
