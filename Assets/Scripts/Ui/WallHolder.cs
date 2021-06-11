using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
    public class WallHolder : MonoBehaviour
    {
        public static WallHolder Instance { get; private set; }
        public Image wallImage;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                wallImage = GetComponent<Image>();
                return;
            }

            Destroy(gameObject);
        }

        public bool IsInside(Image objectImage)
        {
            var wallRect = GetWorldRect(wallImage.rectTransform);
            var objectRect = GetWorldRect(objectImage.rectTransform);

            return wallRect.xMin <= objectRect.xMin
                && wallRect.yMin <= objectRect.yMin
                && wallRect.xMax >= objectRect.xMax
                && wallRect.yMax >= objectRect.yMax;
        }
        
        public static Rect GetWorldRect(RectTransform rectTransform)
        {
            var corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            Vector2 min = corners[0];
            Vector2 max = corners[2];
            Vector2 size = max - min;

            return new Rect(min, size);
        }
    }
}
