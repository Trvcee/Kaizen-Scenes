using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnTriggerEnterTargetObj : MonoBehaviour
{
    // Script assumes that only one main target is colliding at a time
    public Collider[] mainTarget;
    public bool disableAfterCollision;
    private List<int> targetInZone;
    public UnityEvent onTriggerEventEnter;
    public UnityEvent onTriggerEventExit;

    private void Start()
    {
        targetInZone = new List<int>();
        for (int i = 0; i < mainTarget.Length; i++) targetInZone.Add(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < mainTarget.Length; i++)
        {
            if (mainTarget[i] != null)
            {
                if (other.name == mainTarget[i].gameObject.name)
                {
                    targetInZone[i] = targetInZone[i] + 1;
                    if (targetInZone[i] == 1)
                    {
                        onTriggerEventEnter.Invoke(); // Only runs on first enter
                        EnterTriggered(i);
                        if (disableAfterCollision) mainTarget[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    protected virtual void EnterTriggered(int i)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < mainTarget.Length; i++)
        {
            if (mainTarget[i] != null && other.name == mainTarget[i].name)
            {
                targetInZone[i] = targetInZone[i] - 1;
                if (targetInZone[i] <= 0)
                {
                    onTriggerEventExit.Invoke();
                    ExitTriggered(i);
                }
            }
        }
    }

    protected virtual void ExitTriggered(int i)
    {

    }
}