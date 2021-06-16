using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class Djzada : MonoBehaviour
    {
        public static Djzada Instance;

        [SerializeField] int[] dayCountToChangeMusic;

        int currentMusic = 0;
        int currentDayCounted;

        private void Awake()
        {
            Instance = this;
        }

          public void StartFirstMusic()
        {
            currentMusic = 1;
            MusicSystem.Instance.PlayNextMusic();
        }

        public void ResetMusic()
        {
            currentMusic = 1;
            MusicSystem.Instance.PlayFirstMusic();
        }

        public void CountNextDay()
        {
            currentDayCounted++;

            if (currentMusic < dayCountToChangeMusic.Length - 1)
            if (currentDayCounted >= dayCountToChangeMusic[currentMusic])
            {
                MusicSystem.Instance.PlayNextMusic();
                currentMusic++;
            }
        }
    }
}
