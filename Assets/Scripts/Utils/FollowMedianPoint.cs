using Assets.Scripts.Ui.Interactables;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class FollowMedianPoint : MonoBehaviour
    {
        public Line line;
        public Vector2 distance;

        private void Update()
        {
            transform.position = line.MedianPoint() + distance;
        }
    }
}
