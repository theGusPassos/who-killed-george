﻿using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Interactables;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class LineCreator : MonoBehaviour
    {
        public static LineCreator Instance { get; private set; }
        [SerializeField] Transform lineFather;
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

        private void Update()
        {
            if (lineInstantiated && Input.GetMouseButtonDown(1))
            {
                Destroy(lineInstantiated.gameObject);
            }
        }

        public void InstantiateLine(RectTransform originPosition)
        {
            var objectInstantiated = Instantiate(linePrefab, lineFather);
            lineInstantiated = objectInstantiated.GetComponent<Line>();
            lineInstantiated.GetComponent<RectTransform>().localPosition = Vector2.zero;

            lineInstantiated.SetOriginPostion(originPosition);
        }

        public bool HasLineOnScreen() => lineInstantiated != null;

        public void SetLineTarget(RectTransform targetPosition)
        {
            if (lineInstantiated.originPosition == targetPosition)
                return;

            lineInstantiated.SetTargetPostion(targetPosition);
            lineInstantiated.GetComponent<LineNoteCreator>().EnableNote();
            lineInstantiated = null;
        }
    }
}
