using UnityEngine;

public class ObjectAttachment : MonoBehaviour
{
    public GameObject parentObject; // The object to which you want to attach another object
    public GameObject objectToAttach; // The object that will be attached to the parentObject

    void Start()
    {
        if (parentObject == null || objectToAttach == null)
        {
            Debug.LogError("Please assign both parentObject and objectToAttach in the inspector.");
            return;
        }

        AttachObject();
    }

    void AttachObject()
    {
        // Set the parent of objectToAttach to be parentObject's transform
        objectToAttach.transform.parent = parentObject.transform;

        // Optionally, you can reset the local position and rotation of the attached object
        objectToAttach.transform.localPosition = Vector3.zero;
        objectToAttach.transform.localRotation = Quaternion.identity;
    }
}
