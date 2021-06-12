using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Ui;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class LeadPlacer : MonoBehaviour
    {
        public static LeadPlacer Instance;
        public List<GameObject> leadList;
        [SerializeField] float distanceBetween;

        List<Evidence> allEvidences = new List<Evidence>();

        private void Awake()
        {
            Instance = this;
        }

        public void PlaceLeads(GameObject[] leads)
        {
            for (int i = 0; i < leads.Length; i++)
            {
                var evidence = leads[i].GetComponent<EvidenceType>().evidence;
                if (allEvidences.Contains(evidence))
                    return;

                var distance = new Vector3(distanceBetween * i, 0);
                var lead = Instantiate(leads[i], transform.position + distance, Quaternion.identity, CanvasHolder.Instance.Canvas.transform);
                leadList.Add(lead);
            }
        }
    }
}
