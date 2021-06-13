using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class TextShower : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textMesh;
        CanvasGroup canvasGroup;

        bool hasShown = false;
        float timer;

        [SerializeField] float timeToFade;

        private void Awake()
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void ShowText(string text)
        {
            hasShown = false;
            textMesh.text = text;
            timer = 0;

            StartCoroutine(FadeAndShow());
        }

        private void Update()
        {
            if (hasShown && Input.anyKeyDown)
            {
                Interrogator.Instance.CleanUp();
                hasShown = false;
                StartCoroutine(FadeOut());
            }
        }

        IEnumerator FadeAndShow()
        {
            while (canvasGroup.alpha < 1)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0, 1, timer / timeToFade);


                yield return new WaitForEndOfFrame();
            }

            hasShown = true;
            timer = 0;
        }

        IEnumerator FadeOut()
        {
            while (canvasGroup.alpha > 0)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, timer / timeToFade);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
