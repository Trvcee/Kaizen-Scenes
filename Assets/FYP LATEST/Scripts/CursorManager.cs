using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        // Enable the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Add any additional logic as needed
}
