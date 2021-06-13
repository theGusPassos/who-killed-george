using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Cutscene.Data
{
    public class EndCutsceneData : MonoBehaviour
    {
        public FactsForCutscene[] factsForCutscene;

        public FactsForCutscene GetCutsceneForCurrentFacts(List<Facts> facts)
        {
            foreach (var f in factsForCutscene)
            {
                if (f.factsNecessary == null) return f;

                if (f.factsNecessary.All(value => facts.Contains(value)))
                    return f;
            }

            return null;
        }
    }

    [System.Serializable]
    public class FactsForCutscene
    {
        public GameObject cutscene;
        public List<Facts> factsNecessary;
    }

    public enum Facts
    {
        ArthurMotive,
        a, b, c
    }
}
