using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Ui.Holders;
using Assets.Scripts.Ui.Interactables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Cutscene.Setters
{
    public class SetPhotosInInterrogation : MonoBehaviour
    {
        public static SetPhotosInInterrogation Instance;
        [SerializeField] float distance;
        [SerializeField] RectTransform reference;

        List<GameObject> allPhotos = new List<GameObject>();
        List<Evidence> allEvidences = new List<Evidence>();

        private void Awake()
        {
            Instance = this;
        }

        public void Set()
        {
            var list = LeadPlacer.Instance.leadList;
            for (var i = 0; i < list.Count; i++)
            {
                var d = new Vector3(distance * i, 0) + reference.position;
                var photoPlaced = Instantiate(list[i], d, Quaternion.identity, SecondCanvasHolder.Instance.Canvas.transform);
                photoPlaced.GetComponent<SetAnotherOptionOpener>().Set();
                photoPlaced.GetComponent<Animator>().Play("nothing");
                allPhotos.Add(photoPlaced);
                allEvidences.Add(photoPlaced.GetComponent<EvidenceType>().evidence);
            }
        }

        public void AddPhotos(GameObject[] photos)
        {
            var list = photos;
            for (var i = 0; i < list.Length; i++)
            {
                var evidence = list[i].GetComponent<EvidenceType>().evidence;
                if (allEvidences.Contains(evidence))
                    return;

                var d = new Vector3(distance * i, 0) + reference.position;
                var photoPlaced = Instantiate(list[i], d, Quaternion.identity, SecondCanvasHolder.Instance.Canvas.transform);
                photoPlaced.GetComponent<SetAnotherOptionOpener>().Set();
                allPhotos.Add(photoPlaced);
                allEvidences.Add(evidence);
            }

            LeadPlacer.Instance.PlaceLeads(photos);
        }

        public void DestroyAllPhotos()
        {
            foreach (var photo in allPhotos)
                Destroy(photo);
        }
    }
}
