using Assets.Scripts.Actions;
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

        int currentQuestions = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void SetLinkedEvidences(LinkedEvidence linkedEvidence)
        {
            buttonToInterrogate.SetActive(true);
            currentLinkedEvidence = linkedEvidence;
        }

        public void InterrogateWithEvidences()
        {
            currentQuestions++;

            buttonToInterrogate.SetActive(false);

            // will play the cutscene here
            print(currentLinkedEvidence.text);

            CleanUp();
        }

        void CleanUp()
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
            }
        }

        public void RemoveLink()
        {
            buttonToInterrogate.SetActive(false);
            currentLinkedEvidence = null;
        }
    }
}
