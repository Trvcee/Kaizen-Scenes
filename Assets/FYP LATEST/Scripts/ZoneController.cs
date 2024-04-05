using UnityEngine;

public class ZoneController : MonoBehaviour
{
    // Array of game objects to be enabled when an object enters the sphere collider
    public GameObject[] objectsToEnable;

    // Array of game objects to be disabled when an object enters the sphere collider
    public GameObject[] objectsToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player entered the sphere collider, enable specified objects
            SetObjectsActive(objectsToEnable, true);

            // Disable specified objects
            SetObjectsActive(objectsToDisable, false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the sphere collider, disable specified objects
            SetObjectsActive(objectsToDisable, true);

            // Enable specified objects
            SetObjectsActive(objectsToEnable, false);
        }
    }

    private void SetObjectsActive(GameObject[] objects, bool active)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }
    }
}
