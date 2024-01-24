using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DW.LoadScene
{
    using Sounds;

    public class SwitchScenes : MonoBehaviour
    {
        public void SwitchScene(string nameScene)
        {
            LoadSceneManager.Instance.LoadSceneAsync(nameScene);
            SoundEffectManager.Instance.ClickSound();
        }

        public void QuitGame()
        {
            LoadSceneManager.Instance.QuitGame();
            SoundEffectManager.Instance.ClickSound();
        }
    }
}