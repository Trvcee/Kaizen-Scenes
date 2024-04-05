using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator thisAnimator;


    private int numberOfSeperateEvents;
    public UnityEvent[] Animations;
    public UnityEvent[] eventsAfterAnimationStartsPlaying;
    public UnityEvent[] eventsAfterAnimationStopsPlaying;


    [Header("Booleans")]
    public bool isPlaying;
    public bool playOnAwake;
    public bool[] Conditions;
    public bool[] Invoked;
    public bool StartAlready = false;


    // Start is called before the first frame update
    void Start()
    {
        numberOfSeperateEvents = Animations.Length;
        Conditions = new bool[numberOfSeperateEvents];
        Invoked = new bool[numberOfSeperateEvents];
        thisAnimator = GetComponent<Animator>();

    }

    private void LateUpdate()
    {
        AnimationStarts();
        AnimationEnds();
      
    }

    private void Update()
    {
        if (playOnAwake)
        {
            Animations[0].Invoke();
            playOnAwake = false;
            Invoked[0] = true;
            StartAlready = true;
        }


    }


    bool AnimationIsPlaying() => thisAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f ? isPlaying = false : isPlaying = true;


    public void PlayAnimation()
    {

        for (int i = 0; i < numberOfSeperateEvents; i++)
        {


            if (!AnimationIsPlaying() && Conditions[i])
            {
                Invoked[i] = true;
                Conditions[i] = false;
                Animations[i].Invoke();
                StartAlready = true;

            }
        }
    }

    public void PlayAnimation(int progression)
    {
        if(!AnimationIsPlaying())
        {
           
            Invoked[progression] = true;
            Conditions[progression] = false;
            Animations[progression].Invoke();
            StartAlready = true;
        }
    }

    public void InvokeFunctionAfterAnimation()
    {
        //Before
        AnimationStarts();

        //After
        AnimationEnds();

    }

    private void AnimationEnds()
    {
        for (int i = 0; i < numberOfSeperateEvents; i++)
        {
            if (!AnimationIsPlaying() && Invoked[i] & !StartAlready)
            {
                if (eventsAfterAnimationStopsPlaying.Length > i)
                    eventsAfterAnimationStopsPlaying[i].Invoke();


                Invoked[i] = false;
            }
        }
    }

    private void AnimationStarts()
    {
        for (int i = 0; i < numberOfSeperateEvents; i++)
        {
            if (AnimationIsPlaying() && Invoked[i])
            {
                if (eventsAfterAnimationStartsPlaying.Length > i)
                    eventsAfterAnimationStartsPlaying[i].Invoke();
                StartAlready = false;
            }
        }
    }

    public void PlayAnimationOnDelay(float timer)
    {
        foreach (bool k in Conditions)
        {
            if (!AnimationIsPlaying() && k)
                StartCoroutine(Delay(timer));
        }
    }

    public IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayAnimation();
    }

    public void Progresssion(int current)
    {
        for (int i = 0; i < numberOfSeperateEvents; i++)
        {


            if (current == i)
                Conditions[i] = true;

            else
                Conditions[i] = false;
        }
    }

    public void DisableProgression()
    {
        for (int i = 0; i < numberOfSeperateEvents; i++)
        {
            Conditions[i] = false;
        }
    }

}
