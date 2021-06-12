using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Interactables
{
    public class LinkableInterrogation : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform targetTransform;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (InterrogationLineCreator.Instance.HasLineOnScreen())
            {
                InterrogationLineCreator.Instance.SetLineTarget(targetTransform);
            }
        }
    }

}
