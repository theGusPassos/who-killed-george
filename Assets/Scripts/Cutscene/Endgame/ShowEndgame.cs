using Assets.Scripts.Cutscene.Data;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene.Endgame
{
    public class ShowEndgame : MonoBehaviour
    {
        public static ShowEndgame Instance;
        
        CanvasGroup canvasGroup;

        [SerializeField] float timeToBackgroundFade;
        [SerializeField] float timeToFade;
        float timer;


        private void Awake()
        {
            Instance = this;
            canvasGroup = GetComponent<CanvasGroup>();
        }

        [SerializeField] TextMeshProUGUI textMesh;

        public void StartCutscene(EndCutsceneData accusedText)
        {
            var a = accusedText.GetCutsceneForCurrentFacts(FactDataHolder.Instance.facts);
            Instantiate(a.cutscene);
        }

        IEnumerator ShowUI()
        {
            while (canvasGroup.alpha < 1)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0, 1, timer / timeToBackgroundFade);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
