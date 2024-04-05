using UnityEngine;

namespace BNG
{
    public class GrabbableHighlightBK : GrabbableEvents
    {
        public bool HighlightOnGrabbable = true;
        public bool HighlightOnRemoteGrabbable = true;

        private Renderer[] childRenderers;
        private Material[] originalMaterials;
        public Material highlightMaterial; // Assign this in the Unity Editor

        void Start()
        {
            // Get all child renderers
            childRenderers = GetComponentsInChildren<Renderer>();

            // Ensure that there are child renderers
            if (childRenderers == null || childRenderers.Length == 0)
            {
                Debug.LogError("No child renderers found!");
                return;
            }

            // Store the original materials for each child
            originalMaterials = new Material[childRenderers.Length];
            for (int i = 0; i < childRenderers.Length; i++)
            {
                originalMaterials[i] = childRenderers[i].material;
            }

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
            // Set the materials of all child renderers to the highlight material
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = highlightMaterial;
            }
        }

        public void UnhighlightItem()
        {
            // Restore the original materials for each child
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = originalMaterials[i];
            }
        }
    }
}
