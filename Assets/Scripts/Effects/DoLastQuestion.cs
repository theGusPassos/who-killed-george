using Assets.Scripts.Cutscene;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class DoLastQuestion : MonoBehaviour
    {
        private void Awake()
        {
            Interrogator.Instance.SetLastQuestion();
        }
    }
}
