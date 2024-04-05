using UnityEngine;

namespace BNG
{
    public class ItemReleaseInteraction : MonoBehaviour
    {
        public SnapZone snapHolster; // Drag the snapping holster here in the inspector
        public SnapZone originalHolster; // Drag the original holster here in the inspector

        private void OnTriggerEnter(Collider other)
        {
            // Check if the entered collider is the snapping holster
            if (other.gameObject == snapHolster.gameObject)
            {
                // Snap to the snapping holster
                SnapToHolster(snapHolster);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Check if the exited collider is the snapping holster
            if (other.gameObject == snapHolster.gameObject)
            {
                // Snap to the original holster
                SnapToHolster(originalHolster);
            }
        }

        private void SnapToHolster(SnapZone holster)
        {
            // Check if there is a holster
            if (holster != null)
            {
                // Check if the item is currently held
                if (holster.HeldItem != null)
                {
                    // Snap the item to the specified holster
                    holster.GrabGrabbable(holster.HeldItem);
                }
                else
                {
                    Debug.LogError("The specified holster does not have a held item.");
                }
            }
            else
            {
                Debug.LogError("Holster is not assigned to the ItemReleaseInteraction script.");
            }
        }
    }
}
