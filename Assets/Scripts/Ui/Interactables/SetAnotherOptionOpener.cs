using UnityEngine;

namespace Assets.Scripts.Ui.Interactables
{
    public class SetAnotherOptionOpener : MonoBehaviour
    {
        [SerializeField] GameObject otherOptionOpener;

        public void Set()
        {
            GetComponent<Draggable>().options = otherOptionOpener;
        }
    }
}
