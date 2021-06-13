using Assets.Scripts.Cutscene.Data;
using Assets.Scripts.Cutscene.Endgame;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
                MarkNext();
        }

        public void MarkNext()
        {
            if (currentMarker == placesToMark.Length - 1)
            {
                buttonToGiveUp.SetActive(true);
                Instantiate(marker, placesToMark[currentMarker].transform.position, Quaternion.identity, transform);
            }

            else if (currentMarker == placesToMark.Length)
            {
                var t = GetComponentInParent<EndCutsceneData>();
                ShowEndgame.Instance.StartCutscene(t);
            }

            else
            {
                Djzada.Instance.CountNextDay();
                SetRemainingDays(placesToMark.Length - currentMarker - 1);
                Instantiate(marker, placesToMark[currentMarker].transform.position, Quaternion.identity, transform);
            }

            currentMarker++;
        }

        void SetRemainingDays(int remainingDays)
        {
            textMeshPro.text = $"{remainingDays} day{(remainingDays == 1 ? "" : "s")} to the execution";
        }
    }
}
