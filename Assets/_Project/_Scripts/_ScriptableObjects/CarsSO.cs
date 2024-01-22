using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "cars", menuName = "ScriptableObjects/car", order = 0)]
    public class CarsSO : ScriptableObject
    {
        public GameObject car;
    }
}