using UnityEngine;

namespace BNG
{

    public class GrabbableHighlight : GrabbableEvents
    {

        public bool HighlightOnGrabbable = true;
        public bool HighlightOnRemoteGrabbable = true;

        private Material originalMaterial;
        public Material highlightMaterial; // Assign this in the Unity Editor

        void Start()
        {
            // Assuming the script is attached to the object with a Renderer component
            Renderer renderer = GetComponent<Renderer>();

            // Store the original material
            originalMaterial = renderer.material;

            // Ensure that the highlightMaterial is assigned in the Unity Editor
            if (highlightMaterial == null)
            {
                Debug.LogError("Highlight material is not assigned!");
            }
        }

        public override void OnGrab(Grabber grabber)
        {
            UnhighlightItem();
        }

        public override void OnBecomesClosestGrabbable(ControllerHand touchingHand)
        {
            if (HighlightOnGrabbable)
            {
                HighlightItem();
            }
        }

        public override void OnNoLongerClosestGrabbable(ControllerHand touchingHand)
        {
            if (HighlightOnGrabbable)
            {
                UnhighlightItem();
            }
        }

        public override void OnBecomesClosestRemoteGrabbable(ControllerHand touchingHand)
        {
            if (HighlightOnRemoteGrabbable)
            {
                HighlightItem();
            }
        }

        public override void OnNoLongerClosestRemoteGrabbable(ControllerHand touchingHand)
        {
            if (HighlightOnRemoteGrabbable)
            {
                UnhighlightItem();
            }
        }

        public void HighlightItem()
        {
            // Set the object's material to the highlight material
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = highlightMaterial;
        }

        public void UnhighlightItem()
        {
            // Restore the original material
            Renderer renderer = GetComponent<Renderer>();
            renderer.material = originalMaterial;
        }
    }
}
