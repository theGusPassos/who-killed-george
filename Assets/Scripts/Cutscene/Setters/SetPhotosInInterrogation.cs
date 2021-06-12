using Assets.Scripts.Ui.Holders;
using Assets.Scripts.Ui.Interactables;
using UnityEngine;

namespace Assets.Scripts.Cutscene.Setters
{
    public class SetPhotosInInterrogation : MonoBehaviour
    {
        public static SetPhotosInInterrogation Instance;
        [SerializeField] float distance;
        [SerializeField] RectTransform reference;

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
            }
        }
    }
}
