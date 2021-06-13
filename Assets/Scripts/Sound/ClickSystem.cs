using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class ClickSystem : MonoBehaviour
    {
        public static ClickSystem Instance;
        private AudioSource audioSource;

        public AudioClip clickPhoto;
        public AudioClip releasePhoto;
        public AudioClip click;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            audioSource = GetComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }

        public void PlayClick()
        {
            audioSource.PlayOneShot(click);
        }
        public void PlayClickPhoto()
        {
            audioSource.PlayOneShot(clickPhoto);
        }
        public void PlayClickRelease()
        {
            audioSource.PlayOneShot(releasePhoto);
        }
    }
}
