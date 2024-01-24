using UnityEngine;

namespace DW.Sounds
{
    public class SoundEffectManager : MonoBehaviour
    {
        public static SoundEffectManager Instance { get; private set; }

        [SerializeField] AudioSource audioManager;

        [SerializeField] private AudioClip clickSound;
        [SerializeField] private AudioClip accessDenied;
        [SerializeField] private AudioClip coinUsed;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else Destroy(this.gameObject);
        }

        public void ClickSound()
        {
            audioManager.PlayOneShot(clickSound);
        }
        public void AccessDenied()
        {
            audioManager.PlayOneShot(accessDenied);
        }
        public void CoinUsed()
        {
            audioManager.PlayOneShot(coinUsed);
        }
    }
}