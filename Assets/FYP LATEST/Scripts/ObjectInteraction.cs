using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectToInteractWith;  // Drag the object you want to interact with in the Unity Editor
    public GameObject objectToEnable;        // Drag the object you want to enable in the Unity Editor

    private void Update()
    {
        // Check for user interaction, for example, using the mouse click
        if (Input.GetMouseButtonDown(0))  // Assumes left mouse button click
        {
            // Raycast to check if the user clicked on the objectToInteractWith
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == objectToInteractWith)
            {
                // User interacted with objectToInteractWith, enable objectToEnable
                objectToEnable.SetActive(true);
                Debug.Log(objectToEnable.name + " has been enabled!");
            }
        }
    }
}

