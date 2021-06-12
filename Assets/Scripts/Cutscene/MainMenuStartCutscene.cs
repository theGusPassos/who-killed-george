using Assets.Scripts.Scene;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cutscene
{
    public class MainMenuStartCutscene : MonoBehaviour
    {
        public Image logoImage;
        public CanvasGroup credits;
        public TextMeshProUGUI start;

        public float timeToStartShowing;
        public float timeToShowLogo;
        public float timeToShowImage;
        public float timeToShowCredits;
        float timer;

        bool canStartGame;

        private void Awake()
        {
            logoImage.color -= new Color(0, 0, 0, 1);
            credits.alpha = 0;
            start.color -= new Color(0, 0, 0, 1);
        }

        private void Start()
        {
            StartCoroutine(ShowLogo());
        }

        IEnumerator ShowLogo()
        {
            yield return new WaitForSeconds(timeToStartShowing);
            while (logoImage.color.a < 1)
            {
                timer += Time.deltaTime;
                var color = logoImage.color;
                color.a = Mathf.Lerp(0, 1, timer / timeToShowLogo);
                logoImage.color = color;

                yield return new WaitForEndOfFrame();
            }

            timer = 0;
            StartCoroutine(ShowCredits());
        }

        IEnumerator ShowCredits()
        {
            yield return new WaitForSeconds(timeToShowCredits);

            while (credits.alpha < 1)
            {
                timer += Time.deltaTime;
                credits.alpha = Mathf.Lerp(0, 1, timer / timeToShowImage);

                yield return new WaitForEndOfFrame();
            }

            timer = 0;
            StartCoroutine(ShowStartMessage());
        }

        IEnumerator ShowStartMessage()
        {
            yield return new WaitForSeconds(0.5f);

            canStartGame = true;

            while (start.color.a < 1)
            {
                timer += Time.deltaTime;
                var color = logoImage.color;
                color.a = Mathf.Lerp(0, 1, timer / timeToShowImage);
                start.color = color;

                yield return new WaitForEndOfFrame();
            }
        }

        private void Update()
        {
            if (canStartGame && Input.anyKeyDown)
            {
                SceneLoader.Instance.LoadScene("Wall Scene");
            }
        }
    }
}
