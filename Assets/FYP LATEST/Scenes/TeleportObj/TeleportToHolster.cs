
using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class TeleportToHolster : MonoBehaviour
{
    public Transform HolsterRight1;

    public void TeleportObject()
    {
        if (HolsterRight1 != null)
        {
            transform.position = HolsterRight1.position;
        }
    }

}   