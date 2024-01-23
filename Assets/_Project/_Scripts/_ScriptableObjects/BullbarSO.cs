using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "bullbar", menuName = "ScriptableObjects/bullbar", order = 2)]
    public class BullbarSO : ScriptableObject
    {
        public string typeName = "Bull Bar";
        public string name;
        public Sprite image;
        public MeshFilter carBullBar;

        public int indexToSelectCustom;
        public int value;
        public bool equiped;
        public bool resaleAuthorization;
        public bool locked = true;
    }
}