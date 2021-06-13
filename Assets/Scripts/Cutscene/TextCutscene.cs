using Assets.Scripts.Scene;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class TextCutscene : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] textMeshs;
        [SerializeField] float timeToStart;
        [SerializeField] float fadeTime;
        [SerializeField] float timeBetweenTexts;
        [SerializeField] string sceneToLoad;

        float countingTimeBetweenTexts;
        bool canStart = false;
        int currentText;

        float timer;

        private void Awake()
        {
            textMeshs = GetComponentsInChildren<TextMeshProUGUI>();
            StartCoroutine(FadeAndShowText());
        }

        private void Update()
        {
            if (canStart)
            {
                if (Input.anyKeyDown)
                    SceneLoader.Instance.LoadScene(sceneToLoad);
            }
            else if (Input.anyKeyDown)
            {
                // skip
                if (countingTimeBetweenTexts > 0)
                {
                    countingTimeBetweenTexts = timeBetweenTexts;
                }
                else
                {
                    var color = textMeshs[currentText].color;
                    color.a = 1;
                    textMeshs[currentText].color = color;
                }
            }
        }

        IEnumerator FadeAndShowText()
        {
            yield return new WaitForSeconds(timeToStart);
            for (int i = 0; i < textMeshs.Length; i++)
            {
                var textMesh = textMeshs[i];
                while (textMesh.color.a < 1)
                {
                    timer += Time.deltaTime;
                    var color = textMesh.color;
                    color.a = Mathf.Lerp(0, 1, timer / fadeTime);
                    textMesh.color = color;

                    yield return new WaitForEndOfFrame();
                }

                while (countingTimeBetweenTexts < timeBetweenTexts)
                {
                    countingTimeBetweenTexts += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }

                countingTimeBetweenTexts = 0;
                currentText++;
                timer = 0;
            }

            canStart = true;
        }
    }
}
