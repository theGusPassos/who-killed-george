using Assets.Scripts.Cutscene.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Cutscene
{
    public class FactDataHolder : MonoBehaviour
    {
        public static FactDataHolder Instance;
        public List<Facts> facts;

        private void Awake()
        {
            Instance = this;
        }

        private void OnLevelWasLoaded(int level)
        {
            ResetFacts();
        }

        public void ResetFacts() => facts = new List<Facts>();
    }
}
