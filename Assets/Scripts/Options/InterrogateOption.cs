using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class InterrogateOption : MonoBehaviour, IPointerDownHandler
    {
        CharacterData characterData;
        [SerializeField] InterrogationDataHolder interrogationDataHolder;

        public void OnPointerDown(PointerEventData eventData)
        {
            InterrogationStarter.Instance.StartInterrogation(characterData, interrogationDataHolder.GetNext());
        }

        private void Awake()
        {
            characterData = GetComponentInParent<CharacterData>();
        }
    }
}
