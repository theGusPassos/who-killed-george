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

        private void Update()
        {
            if (originPosition == null)
                return;

            var points = new Vector2[2];
            points[0] = originPosition.anchoredPosition + distanceFromPos;
            print(points[0]);

            Vector2 local;
            if (targetPosition != null)
                points[1] = targetPosition.anchoredPosition + distanceFromPos;
            else
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(WallHolder.Instance.wallImage.rectTransform,
            Input.mousePosition, Camera.main, out local);
                points[1] = local;
            }

            uiLineRenderer.Points = points;
        }
    }
}
