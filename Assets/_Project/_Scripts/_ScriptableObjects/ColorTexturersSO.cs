using UnityEngine;
using UnityEngine.UI;

namespace DW.SO
{
    [CreateAssetMenu(fileName = "Painting", menuName = "ScriptableObjects/painting", order = 1)]
    public class ColorTexturersSO : ScriptableObject
    {
        public string typeName = "Paintings";
        public string name;
        public Color color;

        public int indexToSelectCustom;
        public int value;
        public bool equiped;
        public bool resaleAuthorization;
        public bool locked = true;
    }
}