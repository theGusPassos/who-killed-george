using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.UI.Text;
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
        [SerializeField] float timeToShowCharacterName;
        [SerializeField] TextMeshProUGUI characterNameMesh;
        [SerializeField] float timeToStartTyping;
        [SerializeField] TextTyper textTyper;

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

        IEnumerator TypeTextTyper()
        {
            yield return new WaitForSeconds(timeToStartTyping);

        }
    }
}
