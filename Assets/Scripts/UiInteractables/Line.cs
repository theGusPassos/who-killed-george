using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Assets.Scripts.UiInteractables
{
    public class Line : MonoBehaviour
    {
        UILineRenderer uiLineRenderer;
        [SerializeField] RectTransform[] originAndDestiny;

        protected void Awake()
        {
            uiLineRenderer = GetComponent<UILineRenderer>();
        }

        private void Update()
        {
            var points = new Vector2[2];
            points[0] = originAndDestiny[0].anchoredPosition;
            print(points[0]);
            points[1] = originAndDestiny[1].anchoredPosition;

            uiLineRenderer.Points = points;
        }
    }
}
