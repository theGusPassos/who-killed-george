using Assets.Scripts.Ui.Interactables;
using UnityEngine;

namespace Assets.Scripts.Ui.Menus
{
    public class LineCreator : MonoBehaviour
    {
        public static LineCreator Instance { get; private set; }
        [SerializeField] GameObject linePrefab;

        Line lineInstantiated;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }

            Destroy(gameObject);
        }

        public void InstantiateLine(RectTransform originPosition)
        {
            var objectInstantiated = Instantiate(linePrefab, CanvasHolder.Instance.Canvas.transform);
            lineInstantiated = objectInstantiated.GetComponent<Line>();
            lineInstantiated.GetComponent<RectTransform>().localPosition = Vector2.zero;

            lineInstantiated.SetOriginPostion(originPosition);
        }

        public bool HasLineOnScreen() => lineInstantiated != null;

        public void SetLineTarget(RectTransform targetPosition)
        {
            lineInstantiated.SetTargetPostion(targetPosition);
            lineInstantiated = null;
        }
    }
}
