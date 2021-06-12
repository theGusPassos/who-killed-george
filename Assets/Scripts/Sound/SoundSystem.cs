using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundSystem : MonoBehaviour
    {
        public static SoundSystem Instance;
        private AudioSource audioSource;

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

        public void PlaySoundEffect(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
