using Assets.Scripts.Cutscene;
using Assets.Scripts.Ui.Holders;
using Assets.Scripts.Ui.Interactables;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class InterrogationLineCreator : MonoBehaviour
    {
        public static InterrogationLineCreator Instance { get; private set; }
        [SerializeField] GameObject linePrefab;

        Line lineInstantiated;
        Evidence evidence;
        bool lineConnected;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        public void InstantiateLine(RectTransform originPosition, Evidence evidence)
        {
            if (lineInstantiated != null)
            {
                Destroy(lineInstantiated.gameObject);
                InterrogationStarter.Instance.OnEvidenceDiselected();
            }

            lineConnected = false;
            var objectInstantiated = Instantiate(linePrefab, SecondCanvasHolder.Instance.Canvas.transform);
            lineInstantiated = objectInstantiated.GetComponent<Line>();
            lineInstantiated.GetComponent<RectTransform>().localPosition = Vector2.zero;
            this.evidence = evidence;

            lineInstantiated.SetOriginPostion(originPosition);
        }

        public bool HasLineOnScreen() => lineInstantiated != null && !lineConnected;

        public void SetLineTarget(RectTransform targetPosition, Evidence evidence)
        {
            lineInstantiated.SetTargetPostion(targetPosition);
            InterrogationStarter.Instance.OnEvidencesSelected(this.evidence, evidence);
            lineConnected = true;
        }

        public void DestroyLine()
        {
            Destroy(lineInstantiated.gameObject);
            InterrogationStarter.Instance.OnEvidenceDiselected();
            lineConnected = false;
        }
    }
}
