using Assets.Scripts.Actions;
using Assets.Scripts.Calendar;
using Assets.Scripts.Cutscene.Setters;
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
        }

        public void CleanUp()
        {
            if (currentLinkedEvidence.leads != null && currentLinkedEvidence.leads.Length > 0)
            {
                SetPhotosInInterrogation.Instance.AddPhotos(currentLinkedEvidence.leads);
            }

            InterrogationLineCreator.Instance.DestroyLine();

            if (currentQuestions == numberOfQuestions)
            {
                currentQuestions = 0;
                SetPhotosInInterrogation.Instance.DestroyAllPhotos();
                InterrogationStarter.Instance.Finish();
                DayRoutine.Instance.MarkNext();
            }
        }

        public void RemoveLink()
        {
            buttonToInterrogate.SetActive(false);
            currentLinkedEvidence = null;
        }
    }
}
