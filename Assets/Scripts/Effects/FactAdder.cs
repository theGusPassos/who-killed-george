using Assets.Scripts.Cutscene;
using Assets.Scripts.Cutscene.Data;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class FactAdder : MonoBehaviour
    {
        [SerializeField] Facts factToAdd;

        private void Awake()
        {
            FactDataHolder.Instance.facts.Add(factToAdd);
        }
    }
}
