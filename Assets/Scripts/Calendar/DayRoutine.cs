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

        [SerializeField] GameObject buttonToGiveUp;

        private void Awake()
        {
            Instance = this;
        }

        public void MarkNext()
        {
            if (currentMarker == placesToMark.Length - 1)
            {
                buttonToGiveUp.SetActive(true);
            }

            Instantiate(marker, placesToMark[currentMarker++].transform.position, Quaternion.identity, transform);
        }
    }
}
