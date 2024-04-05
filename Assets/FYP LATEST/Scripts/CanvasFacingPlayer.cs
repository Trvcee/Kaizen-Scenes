using UnityEngine;

public class CanvasFacingPlayer : MonoBehaviour
{
    // Reference to the player's VR camera (assumes it's the main camera)
    public Transform playerCamera;

    void Start()
    {
        // If the playerCamera is not assigned, try to find the main camera
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    void Update()
    {
        // Ensure we have a valid reference to the playerCamera
        if (playerCamera != null)
        {
            // Calculate the direction from the Canvas to the playerCamera
            Vector3 lookDirection = playerCamera.position - transform.position;

            // Keep the Canvas facing the player by updating its rotation
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else
        {
            Debug.LogWarning("Player camera not found. Make sure to assign the playerCamera variable or ensure there is a main camera in the scene.");
        }
    }
}
