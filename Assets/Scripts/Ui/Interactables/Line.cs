using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Assets.Scripts.Ui.Interactables
{
    public class Line : MonoBehaviour
    {
        UILineRenderer uiLineRenderer;

        RectTransform originPosition;
        RectTransform targetPosition;

        [SerializeField] Vector2 distanceFromPos;

        protected void Awake()
        {
            uiLineRenderer = GetComponent<UILineRenderer>();
        }

        public void SetOriginPostion(RectTransform originPosition)
            => this.originPosition = originPosition;

        public void SetTargetPostion(RectTransform targetPosition)
            => this.targetPosition = targetPosition;

        public Vector2 MedianPoint()
            => Vector2.Lerp(originPosition.position, targetPosition.position, 0.5f);

        private void Update()
        {
            if (originPosition == null)
                return;

            var points = new Vector2[2];
            points[0] = originPosition.anchoredPosition + distanceFromPos;

            if (targetPosition != null)
                points[1] = targetPosition.anchoredPosition + distanceFromPos;
            else
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    CanvasHolder.Instance.Canvas.GetComponent<RectTransform>(),
                         Input.mousePosition, Camera.main, out Vector2 local);
                points[1] = local;
            }

            uiLineRenderer.Points = points;
        }
    }
}
