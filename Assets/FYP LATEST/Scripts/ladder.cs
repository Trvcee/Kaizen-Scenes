using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ladder : MonoBehaviour
{
    public UnityEvent DoSomething;
    public UnityEvent DoSomething2;
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
        if (other.CompareTag("Ladder"))
            DoSomething.Invoke();
    }
}
