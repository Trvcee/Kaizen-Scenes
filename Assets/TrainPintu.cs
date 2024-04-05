using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Doors
{
    public GameObject personalTime;
    public GameObject trainTime;
}
public class TrainPintu : MonoBehaviour
{
    public int counter;
    public Animator animator;
    public Animator trainAnimator;
    public AnimationController animationController;
    public AnimationController animationControllerDoor;
    public bool bagiGoyang = false;
    public UnityEvent trainMove;
    public bool occured = false;
    public List<Doors> allTheDoors;

    [HideInInspector]
    public List<AnimationController> animationControllers;

    public GameObject checklist;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("doorClose") && bagiGoyang && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f && !occured)
        {
            trainMove.Invoke();
            occured = true;
          
        }


            checklist.SetActive(counter >= 3);

    }

    private void Awake()
    {
        Initialising();
    }

    private void Initialising()
    {
        foreach (Doors doors in allTheDoors)
        {
            doors.personalTime.SetActive(false);
            doors.trainTime.SetActive(true);
            animationControllers.Add(doors.trainTime.GetComponentInChildren<AnimationController>());
        }
     
    }

    public void Goyang()
    {
        bagiGoyang = true;
    }

    public void MoveTrain()
    {
        if (bagiGoyang)
            trainMove.Invoke();
    }

    public void SyncDoorsTutup()
    {
        foreach(AnimationController something in animationControllers)
        {
            something.PlayAnimation(1);
        }


    }

    public void SyncDoorsBukak()
    {
        foreach (AnimationController something in animationControllers)
            something.PlayAnimation(0);
    }

    public void KAUBAGIAKUKIRA() => counter++;
 
}
