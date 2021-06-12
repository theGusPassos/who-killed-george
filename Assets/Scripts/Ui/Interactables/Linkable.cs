using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Interactables
{
    public class Linkable : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform targetTransform;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (LineCreator.Instance.HasLineOnScreen())
            {
                LineCreator.Instance.SetLineTarget(targetTransform);
            }
        }
    }
}
