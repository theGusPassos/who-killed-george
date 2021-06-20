using Assets.Scripts.Actions;
using Assets.Scripts.Calendar;
using Assets.Scripts.Cutscene.Setters;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class Interrogator : MonoBehaviour
    {
        public int numberOfQuestions = 2;
        public static Interrogator Instance;
        public LinkedEvidence currentLinkedEvidence;
        public GameObject buttonToInterrogate;
        public GameObject tutoText;

        int currentQuestions = 0;

        [SerializeField] TextShower textShower;
        [SerializeField] CanvasGroup dayCutscene;
        [SerializeField] float timeToFade;
        float timer;

        private void Awake()
        {
            Instance = this;
        }

        public void ShowTextInfo()
        {
            tutoText.SetActive(true);
        }

        public void SetLinkedEvidences(LinkedEvidence linkedEvidence)
        {
            buttonToInterrogate.SetActive(true);
            currentLinkedEvidence = linkedEvidence;
            tutoText.SetActive(false);
        }

        public void InterrogateWithEvidences()
        {
            currentQuestions++;

            buttonToInterrogate.SetActive(false);

            // will play the cutscene here
            textShower.ShowText(currentLinkedEvidence.text);

            if (currentLinkedEvidence.objectWithEffects != null)
            foreach (var effect in currentLinkedEvidence.objectWithEffects)
                Instantiate(effect);
        }

        IEnumerator FadeInDayCutscene()
        {
            while (dayCutscene.alpha < 1)
            {
                timer += Time.deltaTime;

                dayCutscene.alpha = Mathf.Lerp(0, 1, timer / timeToFade);

                yield return new WaitForEndOfFrame();
            }

            timer = 0;
            InterrogationStarter.Instance.Finish();
            yield return new WaitForSeconds(0.5f);

            StartCoroutine(FadeOutDayCutscene());
        }

        IEnumerator FadeOutDayCutscene()
        {
            while (dayCutscene.alpha > 0)
            {
                timer += Time.deltaTime;

                dayCutscene.alpha = Mathf.Lerp(1, 0, timer / timeToFade);

                yield return new WaitForEndOfFrame();
            }

            timer = 0;
        }

        public void SetLastQuestion() => currentQuestions = numberOfQuestions;

        public void CleanUp()
        {
            if (currentLinkedEvidence.leads != null && currentLinkedEvidence.leads.Length > 0)
                SetPhotosInInterrogation.Instance.AddPhotosInInterrogation(currentLinkedEvidence.leads);

            InterrogationLineCreator.Instance.DestroyLine();

            if (currentQuestions == numberOfQuestions)
            {
                currentQuestions = 0;
                SetPhotosInInterrogation.Instance.DestroyAllPhotos();
                DayRoutine.Instance.MarkNext();
                StartCoroutine(FadeInDayCutscene());
            }
        }

        public void RemoveLink()
        {
            buttonToInterrogate.SetActive(false);
            currentLinkedEvidence = null;
        }
    }
}
