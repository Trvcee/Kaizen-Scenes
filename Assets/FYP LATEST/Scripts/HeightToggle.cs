using UnityEngine;

public class VRHeightToggle : MonoBehaviour
{
    private bool isSitting = false;

    // Heights for standing and sitting modes
    private float standingHeight = 1.7f; // Adjust this to your standing height in meters
    private float sittingHeight = 2.0f;  // Adjust this to your sitting height in meters

    public void ToggleCameraHeight()
    {
        // Toggle between standing and sitting modes
        isSitting = !isSitting;

        // Set the camera height based on the mode
        float targetHeight = isSitting ? sittingHeight : standingHeight;
        SetCameraHeight(targetHeight);
    }

    void SetCameraHeight(float height)
    {
        // Set the camera height
        Camera.main.transform.parent.localPosition = new Vector3(
            Camera.main.transform.parent.localPosition.x,
            height,
            Camera.main.transform.parent.localPosition.z
        );
    }
}
