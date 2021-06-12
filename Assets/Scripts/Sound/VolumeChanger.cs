using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Sound
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private GameObject musicSource;
        [SerializeField] private GameObject audioSource;

        private List<AudioSource> audioSources = new List<AudioSource>();
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            audioSources.AddRange(musicSource.GetComponents<AudioSource>());
            audioSources.AddRange(audioSource.GetComponents<AudioSource>());
        }

        public void ValueChanged()
        {
            if (audioSources != null)
                foreach (var a in audioSources)
                    a.volume = slider.value;
        }
    }
}
