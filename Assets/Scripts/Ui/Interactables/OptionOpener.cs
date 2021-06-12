using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Interactables
{
    public class OptionOpener : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] public GameObject options;
        [SerializeField] TextMeshProUGUI note;

        bool clicked = false;

        private void Update()
        {
            if (options.activeSelf && Input.GetMouseButtonDown(0) && !clicked)
                HideOptions();

            clicked = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            clicked = true;
            if (!string.IsNullOrEmpty(note.text))
                options.SetActive(true);
        }

        public void HideOptions() => options.SetActive(false);
    }
}
