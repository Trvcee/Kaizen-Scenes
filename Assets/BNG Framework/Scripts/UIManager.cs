using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] NonBishanStaff;
    public GameObject[] SpecialStaffs;
    public GameObject[] VoiceProgressionStaffs;

    public GameObject[] UserInterface;
    public int currentNumber = 0;
    private AudioSource[] NonBishanStaffAudio;
    private AudioSource[] SpecialStaffsAudio;
    private AudioSource[] VoiceProgressionStaffsAudio;

    public UnityEvent[] specialEvents;
    public UnityEvent[] enableTalk;

    private bool dahinvokedlom = false;

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NonBishanStaff.Length; i++)
        {
            if (!NonBishanStaffAudio[i].isPlaying && NonBishanStaff[i].activeSelf)
            {
                if (i == 0)
                    enableTalk[0].Invoke();

                if (i == 5)
                    enableTalk[1].Invoke();


                if (i == 6)
                    enableTalk[2].Invoke();

                if (i == 7)
                    enableTalk[3].Invoke();

                if (i == 8)
                    enableTalk[4].Invoke();

                if (i == 9)
                    enableTalk[5].Invoke();

                if (i == 10)
                    enableTalk[6].Invoke();

                if (i == 11)
                    enableTalk[7].Invoke();



                if (i != 11)
                    ToggleToNextMethod();
            }
        }

        for (int i = 0; i < SpecialStaffs.Length; i++)
        {
            if (!SpecialStaffsAudio[i].isPlaying && SpecialStaffs[i].activeSelf)
            {
                specialEvents[i].Invoke();
            }
        }

        for (int i = 0; i < VoiceProgressionStaffs.Length; i++)
        {
            if (!VoiceProgressionStaffsAudio[i].isPlaying && VoiceProgressionStaffs[i].activeSelf)
            {
                enableTalk[i].Invoke();
            }
        }
    }

    public void Initialize()
    {
        NonBishanStaffAudio = new AudioSource[NonBishanStaff.Length];
        for (int i = 0; i < NonBishanStaff.Length; i++)
        {
            NonBishanStaffAudio[i] = NonBishanStaff[i].GetComponent<AudioSource>();
        }

        for (int i = 0; i < UserInterface.Length; i++)
        {
            UserInterface[i].SetActive(false);
        }


        SpecialStaffsAudio = new AudioSource[SpecialStaffs.Length];
        for (int i = 0; i < SpecialStaffs.Length; i++)
        {
            SpecialStaffsAudio[i] = SpecialStaffs[i].GetComponent<AudioSource>();
        }

        VoiceProgressionStaffsAudio = new AudioSource[VoiceProgressionStaffs.Length];
        for (int i = 0; i < VoiceProgressionStaffs.Length; i++)
        {
            VoiceProgressionStaffsAudio[i] = VoiceProgressionStaffs[i].GetComponent<AudioSource>();
        }
    }

    public void ToggleToNextMethod()
    {
        UserInterface[currentNumber].SetActive(false);
        currentNumber++;
        UserInterface[currentNumber].SetActive(true);
    }

    public void ToggleSatuKali()
    {
        if (!dahinvokedlom)
        {
            ToggleToNextMethod();
            dahinvokedlom = true;
        }

    }
    public bool benda = true;
    public void Permepuan()
    {
        if (benda)
        {
            UserInterface[0].SetActive(benda);
        }
        benda = false;
    }

}
