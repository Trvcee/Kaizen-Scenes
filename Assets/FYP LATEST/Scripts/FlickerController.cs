using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlickerController : MonoBehaviour
{
    public GameObject ON;
    public GameObject OFF;
    public UnityEvent johnfads;
    public bool toggle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!toggle)
        {
            ON.SetActive(false);
            OFF.SetActive(true);
        }

        else
        {
            ON.SetActive(true);
            OFF.SetActive(false);
        }
    }

    public void Toggling()
    {
         toggle = !toggle;
    }


   
}
