using Assets.Scripts.Sound;
using Assets.Scripts.Ui.Interactables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class DeleteLinkOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            ClickSystem.Instance.PlayClick();
            Destroy(GetComponentInParent<Line>().gameObject);
        }
    }
}
