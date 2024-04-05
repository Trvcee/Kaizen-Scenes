using BNG;
using UnityEngine;

namespace Core
{
    public class SnapZoneController : MonoBehaviour
    {
        public SnapZone snapZoneToChange;
        public GameObject originalHeldItem;
        public SnapZone snapZoneToCheck;

        private GrabbableUnityEvents grabbableEvents;

        void Start()
        {
            if (snapZoneToChange == null || originalHeldItem == null || snapZoneToCheck == null)
            {
                Debug.LogError("SnapZone, originalHeldItem, or snapZoneToCheck is not assigned. Please assign them in the inspector.");
            }

            grabbableEvents = originalHeldItem.GetComponent<GrabbableUnityEvents>();

            if (grabbableEvents == null)
            {
                Debug.LogError("The specified originalHeldItem does not have a GrabbableUnityEvents component.");
            }
            else
            {
                // Subscribe to the OnRelease event
                grabbableEvents.onRelease.AddListener(OnRelease);
            }
        }

        // Event handler for OnRelease
        void OnRelease()
        {
            // Check if snapZoneToCheck is interactable
            if (IsSnapZoneInteractable(snapZoneToCheck))
            {
                // Disable the change of held item
                snapZoneToChange.enabled = false;
            }
            else
            {
                // Assign the originalHeldItem as the held item in the SnapZone
                snapZoneToChange.GrabGrabbable(originalHeldItem.GetComponent<Grabbable>());
            }
        }

        bool IsSnapZoneInteractable(SnapZone snapZone)
        {
            // Add any additional checks for interactability here
            // For example, check if there is a grabbable object within the Snap Zone

            return snapZone.ClosestGrabbable != null;
        }
    }
}