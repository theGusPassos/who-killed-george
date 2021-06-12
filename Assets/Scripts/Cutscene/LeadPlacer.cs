using Assets.Scripts.Ui;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class LeadPlacer : MonoBehaviour
    {
        public static LeadPlacer Instance;
        [SerializeField] float distanceBetween;

        private void Awake()
        {
            Instance = this;
        }

        public void PlaceLeads(GameObject[] leads)
        {
            for (int i = 0; i < leads.Length; i++)
            {
                var distance = new Vector3(distanceBetween * i, 0);
                Instantiate(leads[i], transform.position + distance, Quaternion.identity, CanvasHolder.Instance.Canvas.transform);
            }
        }
    }
}
