using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.LoadScene
{
    public class SwitchScenes : MonoBehaviour
    {
        public void SwitchScene(string nameScene)
        {
            LoadSceneManager.Instance.LoadSceneAsync(nameScene);
        }

        public void QuitGame()
        {
            LoadSceneManager.Instance.QuitGame();
        }
    }
}