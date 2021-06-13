using Assets.Scripts.Scene;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class TextCutscene : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] textMeshs;
        [SerializeField] float fadeTime;
        [SerializeField] float timeBetweenTexts;
        bool canStart = false;

        float timer;

        private void Awake()
        {
            StartCoroutine(FadeAndShowText());
        }

        private void Update()
        {
            if (canStart)
                if (Input.anyKeyDown)
                    SceneLoader.Instance.LoadScene("Wall Scene");
        }

        IEnumerator FadeAndShowText()
        {
            foreach (var textMesh in textMeshs)
            {
                while (textMesh.color.a < 1)
                {
                    timer += Time.deltaTime;
                    var color = textMesh.color;
                    color.a = Mathf.Lerp(0, 1, timer / fadeTime);
                    textMesh.color = color;

                    yield return new WaitForEndOfFrame();
                }
                
                yield return new WaitForSeconds(timeBetweenTexts);

                timer = 0;
            }

            canStart = true;
        }
    }
}
