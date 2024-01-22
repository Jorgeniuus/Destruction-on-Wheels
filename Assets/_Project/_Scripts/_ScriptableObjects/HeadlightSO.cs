using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "headlight", menuName = "ScriptableObjects/headlight", order = 6)]
    public class HeadlightSO : ScriptableObject
    {
        public string name;
        public Sprite image;
        public MeshFilter carHeadlight;

        public int indexToSelectCustom;
        public int value;
        public bool equiped;
        public bool resaleAuthorization;
        public bool locked = true;


    }
}