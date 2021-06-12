using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class EnableOnAwake : MonoBehaviour
    {
        [SerializeField] private GameObject toEnable;

        private void Awake()
        {
            toEnable.SetActive(true);
        }
    }
}
