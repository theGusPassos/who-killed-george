using Assets.Scripts.Actions;
using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class LinkInterrogationOption : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform lineOrigin;
        Evidence evidence;

        private void Awake()
        {
            evidence = GetComponentInParent<EvidenceType>().evidence;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ClickSystem.Instance.PlayClick();
            InterrogationLineCreator.Instance.InstantiateLine(lineOrigin, evidence);
        }
    }
}
