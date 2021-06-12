using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Interactables
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        RectTransform rectTransform;
        Image image;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            var oldPos = rectTransform.anchoredPosition;
            rectTransform.anchoredPosition += eventData.delta / CanvasHolder.Instance.Canvas.scaleFactor;

            if (!WallHolder.Instance.IsInside(image))
                rectTransform.anchoredPosition = oldPos;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}
