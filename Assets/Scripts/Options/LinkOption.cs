using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class LinkOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform lineOrigin;

        public void OnPointerDown(PointerEventData eventData)
        {
            LineCreator.Instance.InstantiateLine(lineOrigin);
        }
    }
}
