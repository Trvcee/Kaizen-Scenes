using UnityEngine;

public class ActivateDeactivateObjects : MonoBehaviour
{
    public GameObject firstObject;  // Assign the first object in the Inspector
    public GameObject[] otherObjects; // Assign other objects in the Inspector

    void Start()
    {
        ActivateDeactivate();
    }

    void ActivateDeactivate()
    {
        if (firstObject != null && otherObjects != null && otherObjects.Length > 0)
        {
            // Randomly choose one object from otherObjects array
            int randomIndex = Random.Range(0, otherObjects.Length);
            GameObject chosenObject = otherObjects[randomIndex];

            // Activate the first object at the location of the chosen object
            firstObject.SetActive(true);
            firstObject.transform.position = chosenObject.transform.position;

            // Deactivate other objects, excluding the chosen one
            foreach (GameObject obj in otherObjects)
            {
                if (obj != chosenObject)
                {
                    obj.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("Please assign both firstObject and otherObjects in the Inspector.");
        }
    }
}


