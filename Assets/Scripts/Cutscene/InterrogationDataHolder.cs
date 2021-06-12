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
            foreach (var e1 in (Evidence[])Enum.GetValues(typeof(Evidence)))
            {
                foreach (var e2 in (Evidence[])Enum.GetValues(typeof(Evidence)))
                {
                    if (e1 != e2 && GetLinked(e1, e1) == null)
                    linkedEvidences.Add(new LinkedEvidence
                    {
                        e1 = e1,
                        e2 = e2,
                        text = "write on me :)"
                    });
                }
            }
        }

        public LinkedEvidence GetLinked(Evidence e1, Evidence e2)
        {
            return linkedEvidences.FirstOrDefault(a => (e1 == a.e1 && e2 == a.e2) ||
                                                       (e1 == a.e2 && e2 == a.e1));
        }
    }

    [System.Serializable]
    public class LinkedEvidence
    {
        public Evidence e1;
        public Evidence e2;
        public string text;
        public GameObject objectWithEffects;
    }

    public enum Evidence
    {
        Joao,
        Vizinha,
        Claudio,
        AmigoSuspeito,
        Dorgas,
        DocumentosFalsos
    }
}
