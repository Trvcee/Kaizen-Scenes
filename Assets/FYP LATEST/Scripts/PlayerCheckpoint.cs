using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckpoint : MonoBehaviour
{
    public Collider[] colliders;
    
    public UnityEvent[] unityEvents;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            {
                if (other == colliders[i])
                {
                    
                    colliders[i].enabled = false;
                    unityEvents[i].Invoke();
                }
                    
            }
        }
    }
}
