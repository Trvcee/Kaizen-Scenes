using UnityEngine;
using System.Collections.Generic;

public class MoveObjectToPosition : MonoBehaviour
{
    public List<Transform> parentObjects; // Assign the parent objects in the Inspector or dynamically in code
    public List<Transform> childObjects; // Assign the child objects in the Inspector or dynamically in code

    void Start()
    {
        MoveToRandomChildLocation();
    }

    void Update()
    {
        // For demonstration purposes, you could call this in Update to move to new child positions continuously
        // Remove this if you want to move only once at the start
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToRandomChildLocation();
        }
    }

    void MoveToRandomChildLocation()
    {
        // Ensure there are child objects to choose from
        if (childObjects.Count > 0)
        {
            // Choose a random child object
            int randomChildIndex = Random.Range(0, childObjects.Count);
            Transform randomChild = childObjects[randomChildIndex];

            // Iterate through parent objects
            foreach (Transform parentObject in parentObjects)
            {
                // Debug information to check positions
                Debug.Log("Random Child Position: " + randomChild.position);
                Debug.Log("Parent Position: " + parentObject.position);

                // Check if the parent and chosen child positions are the same
                if (parentObject.position == randomChild.position)
                {
                    Debug.Log("Parent and Chosen Child positions are the same. Skipping movement.");
                    continue;
                }

                // Move the parent's position to the chosen child's x-axis while keeping the other axes unchanged
                Vector3 newPosition = new Vector3(randomChild.position.x, parentObject.position.y, parentObject.position.z);
                parentObject.position = newPosition;

                // Activate the parent object
                parentObject.gameObject.SetActive(true);

                // Debug information to check if the child is deactivated
                Debug.Log("Random Child Active: " + randomChild.gameObject.activeSelf);

                // Deactivate only the chosen child object
                randomChild.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("No child objects to choose from.");
        }
    }
}
















