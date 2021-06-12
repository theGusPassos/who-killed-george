using Assets.Scripts.Ui;
using UnityEngine;

namespace Assets.Scripts.Calendar
{
    public class DayRoutine : MonoBehaviour
    {
        public static DayRoutine Instance;

        [SerializeField] GameObject marker;
        [SerializeField] GameObject[] placesToMark;
        int currentMarker;

        private void Awake()
        {
            Instance = this;
        }

        public void MarkNext()
        {
            Instantiate(marker, placesToMark[currentMarker++].transform.position, Quaternion.identity, CanvasHolder.Instance.Canvas.transform);
        }
    }
}
