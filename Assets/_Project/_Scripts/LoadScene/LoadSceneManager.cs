using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DW.LoadScene
{
    public class LoadSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject enableAndDisableCanvas;
        [SerializeField] private CanvasGroup loadingAllCanvasObjects;
        [SerializeField] [Range(0.01f, 3f)] private float fadeTime = 0.5f;

        public static LoadSceneManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else Destroy(this.gameObject);
        }

        public void LoadSceneAsync(string sceneName)
        {
            StartCoroutine(PerformLoadSceneAsync(sceneName));
        }

        private IEnumerator PerformLoadSceneAsync(string sceneName)
        {
            yield return StartCoroutine(CanvasFadeIn());

            var operation = SceneManager.LoadSceneAsync(sceneName);

            while (operation.isDone == false)
            {
                yield return null;
            }
            yield return StartCoroutine(CanvasFadeOut());
        }

        private IEnumerator CanvasFadeIn()
        {
            float start = 0;
            float end = 1;
            float speed = (end - start) / fadeTime;

            loadingAllCanvasObjects.alpha = start;

            while (loadingAllCanvasObjects.alpha < end)
            {
                enableAndDisableCanvas.GetComponent<Canvas>().enabled = true;

                loadingAllCanvasObjects.alpha += speed * Time.deltaTime;
                yield return null;
            }
            loadingAllCanvasObjects.alpha = end;
        }

        private IEnumerator CanvasFadeOut()
        {
            float start = 1;
            float end = 0;
            float speed = (end - start) / fadeTime;

            loadingAllCanvasObjects.alpha = start;

            while (loadingAllCanvasObjects.alpha > end)
            {
                enableAndDisableCanvas.GetComponent<Canvas>().enabled = false;

                loadingAllCanvasObjects.alpha += speed * Time.deltaTime;
                yield return null;
            }
            loadingAllCanvasObjects.alpha = end;
        }
    }
}