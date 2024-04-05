using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionAnimationR: MonoBehaviour
{
    public UnityEvent playAnimation;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("R"))
        {
            // Trigger the animation
            playAnimation.Invoke();
        }
    }
}
