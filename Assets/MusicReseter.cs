using Assets.Scripts.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReseter : MonoBehaviour
{
        private void OnLevelWasLoaded(int level)
        {
            MusicSystem.Instance.PlayFirstMusic();
        }
}
