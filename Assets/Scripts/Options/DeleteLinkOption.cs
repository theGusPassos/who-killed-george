using Assets.Scripts.Ui.Interactables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class DeleteLinkOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Destroy(GetComponentInParent<Line>().gameObject);
        }
    }
}
