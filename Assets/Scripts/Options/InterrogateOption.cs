using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class InterrogateOption : MonoBehaviour, IPointerDownHandler
    {
        CharacterData characterData;
        InterrogationData interrogationData;

        public void OnPointerDown(PointerEventData eventData)
        {
            InterrogationStarter.Instance.StartInterrogation(characterData, interrogationData);
        }

        private void Awake()
        {
            characterData = GetComponentInParent<CharacterData>();
            interrogationData = GetComponentInParent<InterrogationData>();
        }
    }
}
