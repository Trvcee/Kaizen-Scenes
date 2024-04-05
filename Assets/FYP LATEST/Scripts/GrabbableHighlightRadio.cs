using UnityEngine;

namespace BNG
{
    public class GrabbableHighlightRadio : GrabbableEvents
    {
        public bool HighlightOnGrabbable = true;
        public bool HighlightOnRemoteGrabbable = true;

        private Material[] originalMaterials;
        public Material[] highlightMaterials; // Assign these in the Unity Editor

        void Start()
        {
            // Assuming the script is attached to the object with a Renderer component
            Renderer renderer = GetComponent<Renderer>();

            // Store the original materials
            originalMaterials = renderer.materials;

            // Ensure that the highlightMaterials are assigned in the Unity Editor
            if (highlightMaterials == null || highlightMaterials.Length != originalMaterials.Length)
            {
                Debug.LogError("Highlight materials are not assigned or the array length does not match!");
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
            // Set the object's materials to the highlight materials
            Renderer renderer = GetComponent<Renderer>();
            renderer.materials = highlightMaterials;
        }

        public void UnhighlightItem()
        {
            // Restore the original materials
            Renderer renderer = GetComponent<Renderer>();
            renderer.materials = originalMaterials;
        }
    }
}
