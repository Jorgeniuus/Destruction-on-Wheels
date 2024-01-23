using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "tires", menuName = "ScriptableObjects/tires", order = 5)]
    public class TiresSO : ScriptableObject
    {
        public string typeName = "Tires";
        public string name;
        public Sprite image;
        public MeshFilter[] carTires;

        public int indexToSelectCustom;
        public int value;
        public bool equiped;
        public bool resaleAuthorization;
        public bool locked = true;
    }
}