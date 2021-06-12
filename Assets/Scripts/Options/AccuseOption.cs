using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Cutscene.Endgame;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class AccuseOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            ShowEndgame.Instance.StartCutscene(GetComponentInParent<AccusedText>());
        }
    }
}
