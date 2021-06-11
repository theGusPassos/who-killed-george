using Assets.Scripts.Ui;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UiInteractables
{
    public class DraggablePhoto : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
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
            {
                rectTransform.anchoredPosition = oldPos;
                print("notinside");

            }

        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}
