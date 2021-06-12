using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Interactables
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
    {
        Animator animator;
        [SerializeField] public GameObject options;
        RectTransform rectTransform;
        public Image image;
        bool canInteract = true;

        Vector2 positionBeforeDrag;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rectTransform = GetComponent<RectTransform>();
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
            if (canInteract && positionBeforeDrag == rectTransform.anchoredPosition && !options.activeSelf)
            {
                animator.Play("selected");
                options.SetActive(true);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            canInteract = !LineCreator.Instance.HasLineOnScreen() && !InterrogationLineCreator.Instance.HasLineOnScreen();
            positionBeforeDrag = rectTransform.anchoredPosition;
        }

        public void DisableOptions() => options.SetActive(false);

        private void Update()
        {
            if (options.activeSelf && Input.GetMouseButtonDown(0))
            {
                DisableOptions();
                animator.Play("unselected");
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            animator.Play("smol-unzoom");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            animator.Play("smol-zoom");
        }
    }
}
