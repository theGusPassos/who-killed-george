using UnityEngine;

namespace Assets.Scripts.Ui.Interactables
{
    public class CursorChanger : MonoBehaviour
    {
        [SerializeField] Texture2D onHoverCursor;

        void OnMouseOver()
        {
            print("changing");
            Cursor.SetCursor(onHoverCursor, Vector2.zero, CursorMode.Auto);
        }

        void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
