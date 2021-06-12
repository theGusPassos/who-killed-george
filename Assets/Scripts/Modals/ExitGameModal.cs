using UnityEngine;

namespace Assets.Scripts.Modals
{
    public class ExitGameModal : MonoBehaviour
    {
        public GameObject modal;

        private void Update()
        {
            if (!modal.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                modal.SetActive(true);
            }
            else if (modal.activeSelf && Input.anyKeyDown)
            {
                modal.SetActive(false);
            }
        }
    }
}
