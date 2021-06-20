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

        int toReduce;
        int toIncrease;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            current = 0;
            musicSources = GetComponents<AudioSource>();
            musicSources[changing].volume = 0;

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (musicSources[toReduce] != null && musicSources[toReduce].volume > 0)
                musicSources[toReduce].volume -= Time.deltaTime * musicSpeed;

            if (musicSources[toIncrease] != null && musicSources[toIncrease].volume < 1)
                musicSources[toIncrease].volume += Time.deltaTime * musicSpeed;
        }

        public void PlayFirstMusic()
        {
            toIncrease = 0;
            toReduce = musicSources.Length - 1;

            current = 1;
        }

        public void PlayNextMusic()
        {
            toIncrease = current;

            if (current > 0)
            {
                toReduce = current - 1;
            }

            current++;
        }
    }
}
