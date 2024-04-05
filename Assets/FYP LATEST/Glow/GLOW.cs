using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GLOW : MonoBehaviour
{
    public Material glowingMaterial;
    private Material originalMaterial;

    private void Start()
    {
        // Store the original material for later use
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is touched by another collider (e.g., a hand)
        if (other.CompareTag("Player"))
        {
            // Change the material to the glowing material
            GetComponent<Renderer>().material = glowingMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the material when the object is no longer touched
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}