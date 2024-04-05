using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission_Waypoint : MonoBehaviour
{
    public Image img;
    public Transform[] targets;
    public float hideAngleThreshold = 90f; // Threshold angle for hiding the waypoint
    public float arrivalDistanceThreshold = 1f; // Threshold distance for considering the player has arrived

    private Transform selectedTarget;

    private void Start()
    {
        // Randomly select a target from the targets array
        int randomIndex = Random.Range(0, targets.Length);
        selectedTarget = targets[randomIndex];
    }

    private void Update()
    {
        Vector3 targetDirection = selectedTarget.position - Camera.main.transform.position;
        float angle = Vector3.Angle(targetDirection, Camera.main.transform.forward);

        if (angle > hideAngleThreshold || IsPlayerAtTarget())
        {
            img.enabled = false; // Hide the waypoint image
        }
        else
        {
            img.enabled = true; // Show the waypoint image

            Vector2 pos = Camera.main.WorldToScreenPoint(selectedTarget.position);
            Vector2 clampPos = ClampToScreen(pos);

            img.transform.position = clampPos;
        }
    }

    private Vector2 ClampToScreen(Vector2 position)
    {
        Vector2 screenPos = position;
        float halfWidth = img.GetPixelAdjustedRect().width / 2;
        float halfHeight = img.GetPixelAdjustedRect().height / 2;

        float minX = halfWidth;
        float maxX = Screen.width - halfWidth;
        float minY = halfHeight;
        float maxY = Screen.height - halfHeight;

        screenPos.x = Mathf.Clamp(screenPos.x, minX, maxX);
        screenPos.y = Mathf.Clamp(screenPos.y, minY, maxY);

        return screenPos;
    }

    private bool IsPlayerAtTarget()
    {
        float distance = Vector3.Distance(transform.position, selectedTarget.position);
        return distance <= arrivalDistanceThreshold;
    }
}
