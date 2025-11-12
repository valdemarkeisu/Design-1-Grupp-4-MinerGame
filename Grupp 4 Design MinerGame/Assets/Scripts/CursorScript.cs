using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] Texture2D cursorArrow;
    [SerializeField] Texture2D cursorArrowDown;

    private void Start()
    {
        if (cursorArrow != null)
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDown()
    {
        if (cursorArrow != null)
        Cursor.SetCursor(cursorArrowDown, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseUp()
    {
        if (cursorArrow != null)
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
