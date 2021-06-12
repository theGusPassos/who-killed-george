using Assets.Scripts.Cutscene.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cutscene
{
    public class InterrogationStarter : MonoBehaviour
    {
        public static InterrogationStarter Instance;
        CanvasGroup canvasGroup;

        [SerializeField] float timeToFade;
        float timer;

        [SerializeField] Image characterFace;

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

        public void StartInterrogation(CharacterData characterData, InterrogationData interrogationData)
        {
            StartCoroutine(FadeIn());
            StartCoroutine(ShowCharactersFace());
        }

        IEnumerator FadeIn()
        {
            while (canvasGroup.alpha < 1)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0, 1, timer / timeToFade);
                yield return new WaitForEndOfFrame();
            }
        }

        IEnumerator ShowCharactersFace()
        {
            yield return new WaitForSeconds(timeToFade + 0.5f);

            while (characterFace.color.a < 1)
            {
            characterFace.color += new Color(0, 0, 0, Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
