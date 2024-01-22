using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "gun", menuName = "ScriptableObjects/weapon", order = 3)]
    public class WeaponsSO : ScriptableObject
    {
        public string name;
        public Sprite image;
        public MeshFilter[] carGun;

        public int indexToSelectCustom;
        public int value;
        public bool equiped;
        public bool resaleAuthorization;
        public bool locked = true;
    }
}