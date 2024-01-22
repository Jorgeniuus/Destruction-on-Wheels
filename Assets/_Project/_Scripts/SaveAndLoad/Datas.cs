using System;

namespace DW.Save
{
    [Serializable]
    public class Datas
    {
        public string nomeTeste;

        public int coins = 5000;

        public int bullbarSelected = 0;
        public int gunSelected = 0;
        public int headlightSelected = 0;
        public int paintingSelected = 2;
        public int tiresSelected = 0;

        public bool[] getBullbarLocked = { false, false, true, true };
        public bool[] getGunLocked = { false, false, true };
        public bool[] getHeadlightLocked = { false, false, false, false, false };
        public bool[] getPaintingLocked = { false, false, false, false };
        public bool[] getTiresLocked = { false, false, true };
    }
}
