﻿using UnityEngine;

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

        public void ResetMusic() => StartFirstMusic();

        public void CountNextDay()
        {
            currentDayCounted++;
            if (currentDayCounted >= dayCountToChangeMusic[currentMusic])
            {
                MusicSystem.Instance.PlayNextMusic();
                currentMusic++;
            }
        }
    }
}