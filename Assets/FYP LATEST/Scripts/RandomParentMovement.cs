using UnityEngine;
using System.Collections.Generic;

public class RandomParentMovement : MonoBehaviour
{
    public List<GameObject> childObjects = new List<GameObject>(); // List of child objects
    public GameObject parentObject; // The object that will be moved to a random child

    private GameObject lastSelectedChild;

    void Start()
    {
        if (parentObject == null || childObjects.Count == 0)
        {
            Debug.LogError("Please assign both parentObject and at least one childObject in the inspector.");
            return;
        }

        MoveParentToRandomChild();
    }

    void MoveParentToRandomChild()
    {
        // Ensure there is more than one child to select
        if (childObjects.Count < 2)
        {
            Debug.LogError("Not enough child objects to perform random movement. Please add more child objects.");
            return;
        }

        // Randomly select a child object different from the last one
        GameObject randomChild;
        do
        {
            int randomChildIndex = Random.Range(0, childObjects.Count);
            randomChild = childObjects[randomChildIndex];
        } while (randomChild == lastSelectedChild);

        // Update the last selected child
        lastSelectedChild = randomChild;

        // Move the parentObject to the position of the randomChild
        parentObject.transform.position = randomChild.transform.position;
    }

    // Optional: You can call this method to move the parent to a new random child during gameplay
    public void MoveParentToNewRandomChild()
    {
        MoveParentToRandomChild();
    }
}





