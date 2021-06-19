using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Interactables
{
    public class ScalerOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] float scaleTo;
        Vector3 originalScale;

        public void OnPointerEnter(PointerEventData eventData)
        {
            originalScale = transform.localScale;
            transform.localScale *= scaleTo;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = originalScale;
        }
    }
}
