using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class Interrogator : MonoBehaviour
    {
        public static Interrogator Instance;
        public LinkedEvidence currentLinkedEvidence;

        private void Awake()
        {
            Instance = this;
        }

        public void SetLinkedEvidences(LinkedEvidence linkedEvidence)
            => currentLinkedEvidence = linkedEvidence;

        public void InterrogateWithEvidences()
        {
            print(currentLinkedEvidence);
        }
    }
}
