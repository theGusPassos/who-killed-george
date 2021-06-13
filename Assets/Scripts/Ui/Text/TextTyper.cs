using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Text
{
    public class TextTyper : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;
        private int currentLetter;
        private string toType;
        [SerializeField] float timeBetweenWords;
        private float currentTimer;

        [SerializeField] string testString;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Type(testString);
        }

        public void Type(string toType) => this.toType = toType;

        private void Update()
        {
            if (string.IsNullOrEmpty(toType) || currentLetter == toType.Length)
                return;

            currentTimer += Time.deltaTime;

            if (currentTimer > timeBetweenWords)
            {
                textMesh.text += toType[currentLetter];

                // doesnt delay if is space
                if (!string.IsNullOrWhiteSpace(toType[currentLetter].ToString()))
                    currentTimer = 0;

                currentLetter++;
            }
        }
    }
}
