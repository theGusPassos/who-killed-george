using UnityEngine;

namespace Assets.Scripts.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicSystem : MonoBehaviour
    {
        public static MusicSystem Instance;

        [SerializeField] private float musicSpeed;
        private AudioSource[] musicSources;

        private int current = 0;
        private int changing = 1;

        bool startedPlaying;

        AudioSource toReduce;
        AudioSource toIncrease;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);

            current = 0;
            musicSources = GetComponents<AudioSource>();
            musicSources[changing].volume = 0; 
        }

        private void Update()
        {
            if (toReduce != null && toReduce.volume > 0)
                toReduce.volume -= Time.deltaTime * musicSpeed;

            if (toIncrease != null && toIncrease.volume < 1)
                toIncrease.volume += Time.deltaTime * musicSpeed;
        }

        public void PlayFirstMusic()
        {
            toIncrease = musicSources[0];
            toReduce = musicSources[musicSources.Length - 1];

            current = 1;
        }

        public void PlayNextMusic()
        {
            toIncrease = musicSources[current];

            if (current > 0)
            {
                toReduce = musicSources[current - 1];
            }

            current++;
        }
    }
}
