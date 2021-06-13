using Assets.Scripts.Sound;
using TMPro;
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
        [SerializeField] TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            Instance = this;
            SetRemainingDays(placesToMark.Length - currentMarker - 1);
        }

        public void MarkNext()
        {
            if (currentMarker == placesToMark.Length - 1)
            {
                buttonToGiveUp.SetActive(true);
            }

            Djzada.Instance.CountNextDay();
            SetRemainingDays(placesToMark.Length - currentMarker - 1);
            Instantiate(marker, placesToMark[currentMarker++].transform.position, Quaternion.identity, transform);
        }
        
        void SetRemainingDays(int remainingDays)
        {
            textMeshPro.text = $"{remainingDays} day{(remainingDays == 1 ? "" : "s")} to the execution";
        }
    }
}
