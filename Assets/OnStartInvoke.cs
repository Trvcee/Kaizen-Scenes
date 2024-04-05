using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartInvoke : MonoBehaviour
{
    public UnityEvent onStartInvoke;    // Start is called before the first frame update
    [SerializeField]
    private int Delay;
    private void OnEnable()
    {
        StartCoroutine(DoSomething(Delay));
    }

    public IEnumerator DoSomething(int time)
    {
        yield return new WaitForSeconds(time);
        onStartInvoke.Invoke();
    }    

}
