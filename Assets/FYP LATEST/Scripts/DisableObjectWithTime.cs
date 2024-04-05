using UnityEngine;

public class DisableObjectWithTime : MonoBehaviour
{
    [SerializeField] // Add this attribute to expose the variable in the Inspector
    public GameObject objectToDisable;

    public float disableTime = 3f;  // Adjust this value to set the time before disabling

    private void Start()
    {
        // Check if objectToDisable is assigned before trying to disable it
        if (objectToDisable != null)
        {
            // Invoke the DisableObject method after the specified disableTime
            Invoke("DisableObject", disableTime);
        }
        else
        {
            Debug.LogError("Please assign a GameObject to objectToDisable in the Inspector.");
        }
    }

    private void DisableObject()
    {
        // Disable the specified object
        objectToDisable.SetActive(false);
        Debug.Log(objectToDisable.name + " has been disabled after " + disableTime + " seconds.");
    }
}



