using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Label;
    private AudioSource TestSound;
    public Camera Camera1;
    public Camera CameraPlayer;
    public bool completedFirst;

    // Start is called before the first frame update
    void Start()
    {
        TestSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Label.SetActive(true);
        TestSound.Play();
        completedFirst = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Label.SetActive(false);
    }
}
