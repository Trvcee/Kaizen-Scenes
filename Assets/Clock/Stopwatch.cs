using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timeText;
    private float elapsedTime;
    private bool isRunning;



    private void Start()
    {
        ResetStopwatch();



        // Set the anchor and position of the stopwatch UI elements
        RectTransform stopwatchRectTransform = GetComponent<RectTransform>();
        stopwatchRectTransform.anchorMin = new Vector2(1f, 1f);
        stopwatchRectTransform.anchorMax = new Vector2(1f, 1f);
        stopwatchRectTransform.pivot = new Vector2(1f, 1f);
        stopwatchRectTransform.anchoredPosition = new Vector2(-10f, -10f);
    }



    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeText();
        }



        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            StartStopwatch();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopStopwatch();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            ResetStopwatch();




        }




    }



    public void StartStopwatch()
    {
        isRunning = true;
    }



    public void StopStopwatch()
    {
        isRunning = false;
    }



    public void ResetStopwatch()
    {
        elapsedTime = 0f;
        UpdateTimeText();
        StopStopwatch();
    }



    private void UpdateTimeText()
    {
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);
        int milliseconds = (int)((elapsedTime * 100f) % 100f);



        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
