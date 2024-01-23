using UnityEngine;

namespace DW.Menu
{
    public class Settings : MonoBehaviour
    {
        private int _fps = 60;

        private void Start()
        {
            Application.targetFrameRate = _fps;
            Screen.SetResolution(1920, 1080, true);
        }
    }
}