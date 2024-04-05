using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;
using System.Diagnostics;

public class Test : MonoBehaviour
{
    // Minimap
    public GameObject Minimap;
    public bool MinimapEnabled = false;
    // Checkpoint
    public Checkpoint checkpointScript;
    // Inventory
    public GameObject Inventory;
    public bool InventoryEnabled = false;

    public Toggle[] togglingTest;
    

    // Update is called once per frame
    void Update()
    {
       
        
        TogglingMinimap();
        TogglingInventory();
    }

   

    private void TogglingMinimap()
    {
        if (InputBridge.Instance.BButtonDown || Input.GetKeyDown(KeyCode.O))
        {
            MinimapEnabled = !MinimapEnabled;
        }

        Minimap.SetActive(MinimapEnabled);
    }

    //private void TogglingCheckmarks()
    //{
    //    if (checkpointScript.completedFirst && togglingTest.Length != 0)
    //        togglingTest[0].isOn = true;
    //}

    private void TogglingInventory()
    {
        if (InputBridge.Instance.XButtonDown || Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnabled = !InventoryEnabled;
        }

        Inventory.SetActive(InventoryEnabled);
    }

  
}
