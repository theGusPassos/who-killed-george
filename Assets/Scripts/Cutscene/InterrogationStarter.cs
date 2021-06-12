using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Cutscene.Setters;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cutscene
{
    public class InterrogationStarter : MonoBehaviour
    {
        public static InterrogationStarter Instance;
        CanvasGroup canvasGroup;

        [SerializeField] float timeToBackgroundFade;
        [SerializeField] float timeToFade;
        float timer;

        [SerializeField] Image characterFace;
        [SerializeField] TextMeshProUGUI characterNameMesh;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                canvasGroup = GetComponent<CanvasGroup>();
                return;
            }

            Destroy(gameObject);
        }

        public GameObject character;

        private void Start()
        {
            StartInterrogation(character.GetComponent<CharacterData>(), character.GetComponentInChildren<InterrogationDataHolder>()
                .GetLinked(Evidence.AmigoSuspeito, Evidence.Claudio));
        }

        public void StartInterrogation(CharacterData characterData, LinkedEvidence linkedEvidence)
        {
            SetPhotosInInterrogation.Instance.Set();
            StartCoroutine(FadeIn());
            StartCoroutine(ShowCharactersFace(characterData.sprite, characterData.name));
        }

        IEnumerator FadeIn()
        {
            while (canvasGroup.alpha < 1)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0, 1, timer / timeToBackgroundFade);
                yield return new WaitForEndOfFrame();
            }
        }

        IEnumerator ShowCharactersFace(Sprite sprite, string name)
        {
            characterFace.sprite = sprite;
            characterNameMesh.text = name;

            yield return new WaitForSeconds(timeToFade + 0.5f);

            timer = 0;

            while (characterFace.color.a < 1)
            {
                timer += Time.deltaTime;
                var curr = Mathf.Lerp(0, 1, timer / timeToFade);
                characterFace.color = new Color(characterFace.color.r, characterFace.color.g, characterFace.color.b, curr);
                characterNameMesh.color = new Color(255, 255, 255, curr);

                yield return new WaitForEndOfFrame();
            }
        }

        // call after all texts
        IEnumerator FadeOut(GameObject[] leads)
        {
            yield return new WaitForSeconds(timeToBackgroundFade + timeToFade);
            LeadPlacer.Instance.PlaceLeads(leads);

            while (canvasGroup.alpha > 0)
            {
                // reset
                characterFace.color = new Color(characterFace.color.r, characterFace.color.g, characterFace.color.b, 0);
                characterNameMesh.color = new Color(255, 255, 255, 0);

                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, timer / timeToBackgroundFade);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
