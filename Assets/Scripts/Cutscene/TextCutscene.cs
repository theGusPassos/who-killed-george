using Assets.Scripts.Scene;
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

        bool canStart = false;
        int currentText;

        float timer;

        private void Awake()
        {
            textMeshs = GetComponentsInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (canStart)
            {
                if (Input.anyKeyDown)
                    SceneLoader.Instance.LoadScene(sceneToLoad);
            }
            else
            {
                var textMesh = textMeshs[currentText];

                timer += Time.deltaTime;
                var color = textMesh.color;
                color.a = Mathf.Lerp(0, 1, timer / fadeTime);
                textMesh.color = color;

                if (color.a >= 1)
                {
                    currentText++;
                    timer = 0;

                    if (currentText == textMeshs.Length)
                    {
                        canStart = true;
                    }
                }

                if (Input.anyKeyDown)
                {
                    // skip
                    var fullAlpha = textMeshs[currentText].color;
                    fullAlpha.a = 1;
                    textMeshs[currentText].color = fullAlpha;
                }
            }
        }
    }
}
