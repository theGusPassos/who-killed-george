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
        [SerializeField] public GameObject options;

        public void OnPointerDown(PointerEventData eventData)
        {
             options.SetActive(false);
             InterrogationStarter.Instance.StartInterrogation(characterData, interrogationDataHolder);
        }

        private void Awake()
        {
            characterData = GetComponentInParent<CharacterData>();
        }
    }
}
