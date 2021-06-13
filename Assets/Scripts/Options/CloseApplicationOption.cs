using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class CloseApplicationOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            ClickSystem.Instance.PlayClick();
            Application.Quit();
        }
    }
}
