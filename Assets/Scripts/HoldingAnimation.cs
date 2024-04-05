using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingAnimation : MonoBehaviour
{
    public Animator AnimationHandsController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
            Debug.Log("Armature|ArmatureAction_001 is playing");
            AnimationHandsController.Play("Scene");



        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
