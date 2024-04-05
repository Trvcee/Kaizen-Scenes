using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSDOClose : MonoBehaviour
{
    //private Vector3 LastPosition;
    public GameObject LeftLeftDoor;
    public GameObject TargetPosition;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //LastPosition = LeftLeftDoor.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //if (LastPosition.x >= 1.2)
        //{
        //transform.Translate(-LastPosition);
        //}

        MoveLeftLeftDoorActive();
        Debug.Log("Activated");

    }

    void MoveLeftLeftDoorActive()
    {
        if (LeftLeftDoor.transform.position != TargetPosition.transform.position)
        {
            var speedvar = Time.deltaTime * speed;
            LeftLeftDoor.transform.position = Vector3.MoveTowards(LeftLeftDoor.transform.position, TargetPosition.transform.position, speedvar);
        }

    }
}
