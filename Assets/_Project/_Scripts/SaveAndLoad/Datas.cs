using System;

namespace DW.Save
{
    [Serializable]
    public class Datas
    {
        public int coins = 5000;

        public int bullbarSelected = 0;
        public int gunSelected = 0;
        public int headlightSelected = 0;
        public int paintingSelected = 2;
        public int tiresSelected = 0;

        public bool[] verifyBullbarEquiped = { true, false, false, false };
        public bool[] verifyGunEquiped = { true, false, false };
        public bool[] verifyHeadlightEquiped = { true, false, false, false, false };
        public bool[] verifyPaintingEquiped = { false, false, true, false };
        public bool[] verifyTiresEquiped = { true, false, false };

        public bool[] getBullbarLocked = { false, false, true, true };
        public bool[] getGunLocked = { false, false, true };
        public bool[] getHeadlightLocked = { false, false, false, true, true };
        public bool[] getPaintingLocked = { false, false, false, false };
        public bool[] getTiresLocked = { false, false, true };

        //public bool[] authorizedSellBullbar = { false, false, true, true };
        //public bool[] authorizedSellGun = { false, false, true };
        //public bool[] authorizedSellHeadlight = { false, false, false, true, true };
        //public bool[] authorizedSellPainting = { false, false, false, false };
        //public bool[] authorizedSellTires = { false, false, true };
    }
}

