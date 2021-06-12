using Assets.Scripts.Cutscene.Data;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class InterrogationDataHolder : MonoBehaviour
    {
        InterrogationData[] interrogations;
        int currentInterrogation = 0;

        private void Awake()
        {
            interrogations = GetComponents<InterrogationData>();
        }

        public bool HasOtherInterrogation() => currentInterrogation == interrogations.Length;

        public InterrogationData GetNext()
        {
            return interrogations[currentInterrogation++];
        }
    }
}
