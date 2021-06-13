using Assets.Scripts.Actions;
using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class LinkOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform lineOrigin;

        public void OnPointerDown(PointerEventData eventData)
        {
            ClickSystem.Instance.PlayClick();
            LineCreator.Instance.InstantiateLine(lineOrigin);
        }
    }
}
