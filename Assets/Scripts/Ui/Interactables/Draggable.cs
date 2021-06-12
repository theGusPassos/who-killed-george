using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Interactables
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] GameObject options;
        RectTransform rectTransform;
        Image image;
        bool canInteract = true;

        Vector2 positionBeforeDrag;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canInteract) return;
            
            var oldPos = rectTransform.anchoredPosition;
                
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    CanvasHolder.Instance.Canvas.GetComponent<RectTransform>(),
                         Input.mousePosition, Camera.main, out Vector2 local);
            
            rectTransform.anchoredPosition = local;

            if (!WallHolder.Instance.IsInside(image))
                rectTransform.anchoredPosition = oldPos;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (canInteract && positionBeforeDrag == rectTransform.anchoredPosition)
                options.SetActive(true);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            canInteract = !LineCreator.Instance.HasLineOnScreen();
            positionBeforeDrag = rectTransform.anchoredPosition;
        }

        public void DisableOptions() => options.SetActive(false);

        private void Update()
        {
            if (options.activeSelf && Input.GetMouseButtonDown(0))
                DisableOptions();
        }
    }
}
