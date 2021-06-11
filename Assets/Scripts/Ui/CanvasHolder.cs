using UnityEngine;

namespace Assets.Scripts.Ui
{
    public class CanvasHolder : MonoBehaviour
    {
        public static CanvasHolder Instance { get; private set; }
        public Canvas Canvas { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Canvas = GetComponent<Canvas>();

                return;
            }

            Destroy(gameObject);
        }
    }
}
