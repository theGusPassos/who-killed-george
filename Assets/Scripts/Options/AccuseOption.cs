using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Cutscene.Endgame;
using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class AccuseOption : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            var t = GetComponentInParent<EndCutsceneData>();
            ShowEndgame.Instance.StartCutscene(t);
            ClickSystem.Instance.PlayClick();
        }
    }
}
