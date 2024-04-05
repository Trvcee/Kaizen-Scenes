using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject objectToEnable;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a tag
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag you are checking for
        {
            string interactingObjectTag = other.gameObject.tag;
            Debug.Log("Object with tag " + interactingObjectTag + " entered the button collider.");

            EnableObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object has a tag
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag you are checking for
        {
            string interactingObjectTag = other.gameObject.tag;
            Debug.Log("Object with tag " + interactingObjectTag + " exited the button collider.");

            // Optionally, you can disable the object when the collider is exited
            // DisableObject();
        }
    }

    private void EnableObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
    }

    // Optionally, you can add a method to disable the object
    private void DisableObject()
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(false);
        }
    }
}
