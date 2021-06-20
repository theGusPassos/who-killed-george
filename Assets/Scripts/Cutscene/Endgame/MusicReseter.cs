using Assets.Scripts.Sound;
using UnityEngine;

namespace Assets.Scripts.Cutscene.Endgame
{
    public class MusicReseter : MonoBehaviour
    {
        private void OnLevelWasLoaded(int level)
        {
            MusicSystem.Instance.PlayFirstMusic();
        }
    }
}
