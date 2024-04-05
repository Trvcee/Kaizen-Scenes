using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionAnimationL : MonoBehaviour
{
    public UnityEvent playAnimation;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("L"))
        {
            // Trigger the animation
            playAnimation.Invoke();
        }
    }
}
