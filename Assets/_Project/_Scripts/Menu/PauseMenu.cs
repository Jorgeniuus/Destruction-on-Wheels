using UnityEngine;

namespace DW.Menu
{
    using LoadScene;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Canvas panelMenu;

        private bool _switch = true;
        private string _mainMenu = "MainMenu";
        private string _garage = "Garage";

        private void Start()
        {
            LockedAndShowCursorMouse(false);
        }

        private void Update()
        {
            PauseGame();
        }

        private void LockedAndShowCursorMouse(bool locked)
        {
            if(!locked)
                Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;

            Cursor.visible = locked;
        }
        private void PauseGame()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
            {
                _switch = !_switch;
                panelMenu.GetComponent<Canvas>().enabled = !_switch;
                LockedAndShowCursorMouse(!_switch);
                PauseTime(_switch);
            }
        }
        private void PauseTime(bool pause)
        {
            if (pause)
                Time.timeScale = 1f;
            else Time.timeScale = 0f;
        }
        public void BackMainMenu()
        {
            LoadSceneManager.Instance.LoadSceneAsync(_mainMenu);
            PauseTime(true);
        }

        public void BackGarage() 
        {
            LoadSceneManager.Instance.LoadSceneAsync(_garage);
            PauseTime(true);
        }
        public void QuitGabme() => LoadSceneManager.Instance.QuitGame();
    }
}