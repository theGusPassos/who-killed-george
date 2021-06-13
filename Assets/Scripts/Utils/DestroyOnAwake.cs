using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class DestroyOnAwake : MonoBehaviour
    {
        public float timeToDestroy;
        private void Awake()
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}
