using Assets.Scripts.Actions;
using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Interactables
{
    public class LinkableInterrogation : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] RectTransform targetTransform;
        Evidence evidence;

        private void Awake()
        {
            evidence = GetComponentInParent<EvidenceType>().evidence;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (InterrogationLineCreator.Instance.HasLineOnScreen())
            {
                InterrogationLineCreator.Instance.SetLineTarget(targetTransform, evidence);
            }
        }
    }

}
