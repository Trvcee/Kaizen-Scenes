using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR5WP : MonoBehaviour
{
    public GameObject waypointObject;
    public Transform[] targets;
    public float hideAngleThreshold = 90f; // Threshold angle for hiding the waypoint
    public float arrivalDistanceThreshold = 1f; // Threshold distance for considering the player has arrived

    private Transform selectedTarget;
    private Camera mainCamera;
    private GameObject instantiatedWaypoint;

    private void Start()
    {
        // Randomly select a target from the targets array
        int randomIndex = Random.Range(0, targets.Length);
        selectedTarget = targets[randomIndex];

        // Get the main camera in the scene
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 targetDirection = selectedTarget.position - mainCamera.transform.position;
        float angle = Vector3.Angle(targetDirection, mainCamera.transform.forward);

        if (angle > hideAngleThreshold || IsPlayerAtTarget())
        {
            if (instantiatedWaypoint != null)
                instantiatedWaypoint.SetActive(false); // Hide the waypoint object
        }
        else
        {
            if (instantiatedWaypoint == null)
                instantiatedWaypoint = Instantiate(waypointObject, selectedTarget.position, Quaternion.identity); // Instantiate the waypoint object

            instantiatedWaypoint.SetActive(true); // Show the waypoint object
            instantiatedWaypoint.transform.LookAt(mainCamera.transform); // Orient the waypoint object towards the camera
        }
    }

    private bool IsPlayerAtTarget()
    {
        float distance = Vector3.Distance(transform.position, selectedTarget.position);
        return distance <= arrivalDistanceThreshold;
    }
}

