using Assets.Scripts.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class LinkInterrogationOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform lineOrigin;

        public void OnPointerDown(PointerEventData eventData)
        {
            InterrogationLineCreator.Instance.InstantiateLine(lineOrigin);
        }
    }
}
