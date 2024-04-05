using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionAnimation : MonoBehaviour
{
    public UnityEvent playAnimation;
  



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedKnob"))
        {
            // Trigger the animation
            playAnimation.Invoke();
        }
    }
}