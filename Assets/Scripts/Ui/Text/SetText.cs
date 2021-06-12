using TMPro;
using UnityEngine;

namespace Assets.Scripts.Ui.Text
{
    public class SetText : MonoBehaviour
    {
        public string textToWrite;

        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = textToWrite;
        }
    }
}
