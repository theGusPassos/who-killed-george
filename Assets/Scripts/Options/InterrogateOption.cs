using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Options
{
    public class InterrogateOption : MonoBehaviour, IPointerDownHandler
    {
        CharacterData characterData;
        [SerializeField] InterrogationDataHolder interrogationDataHolder;
        [SerializeField] public GameObject options;
        [SerializeField] Animator animator;

        public void OnPointerDown(PointerEventData eventData)
        {
            animator.Play("unselected");
            ClickSystem.Instance.PlayClick();
             options.SetActive(false);
             InterrogationStarter.Instance.StartInterrogation(characterData, interrogationDataHolder);
        }

        private void Awake()
        {
            characterData = GetComponentInParent<CharacterData>();
        }
    }
}
