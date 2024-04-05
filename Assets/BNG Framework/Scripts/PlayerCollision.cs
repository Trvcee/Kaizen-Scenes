using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent[] unityEvents;
    public Collider[] Markers;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

       for (int i = 0; i < Markers.Length; i++)
        {
            if (other == Markers[i])
            {
                unityEvents[i].Invoke();
                
            }
        }
            
    }
}
