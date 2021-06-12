using Assets.Scripts.Ui.Interactables;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class LineNoteCreator : MonoBehaviour
    {
        [SerializeField] GameObject note;
        [SerializeField] Vector2 distance;

        public void EnableNote()
        {
            note.SetActive(true);
            var follow =  note.AddComponent<FollowMedianPoint>();
            follow.line = GetComponent<Line>();
            follow.distance = distance;
        }
    }
}
