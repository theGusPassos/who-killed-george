using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ui.Holders
{
    public class SecondCanvasHolder : MonoBehaviour
    {
        public static SecondCanvasHolder Instance { get; private set; }
        public Canvas Canvas { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Canvas = GetComponent<Canvas>();

                return;
            }

            Destroy(gameObject);
        }
    }
}
