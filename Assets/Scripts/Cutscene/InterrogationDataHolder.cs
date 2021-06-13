using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class InterrogationDataHolder : MonoBehaviour
    {
        [SerializeField] List<LinkedEvidence> linkedEvidences;

        [ContextMenu("generate evidences")]
        public void Generate()
        {
            var t = DifferentCombinations((Evidence[])Enum.GetValues(typeof(Evidence)), 2);
            foreach (var i in t)
            {
                linkedEvidences.Add(new LinkedEvidence
                {
                    e1 = i.First(),
                    e2 = i.Last(),
                    text = "write on me :)"
                });
            }
        }

        public LinkedEvidence GetLinked(Evidence e1, Evidence e2)
        {
            return linkedEvidences.FirstOrDefault(a => (e1 == a.e1 && e2 == a.e2) ||
                                                       (e1 == a.e2 && e2 == a.e1));
        }
        
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                DifferentCombinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
        }

    }

    [System.Serializable]
    public class LinkedEvidence
    {
        public Evidence e1;
        public Evidence e2;
        public string text;
        public GameObject objectWithEffects;
        public GameObject[] leads;
    }

    public enum Evidence
    {
        Agatha,
        Arthur,
        Johnatan,
        Mark,
        Dorgas,
        DocumentosFalsos,
        George
    }
}
