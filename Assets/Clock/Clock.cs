using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text timeText;





    void Start()
    {
        // Update the clock display every second
        InvokeRepeating("UpdateTime", 0f, 1f);
    }





    void UpdateTime()
    {
        // Get the current system time
        System.DateTime currentTime = System.DateTime.Now;





        // Format the time as a string
        string formattedTime = currentTime.ToString("hh:mm:ss tt");





        // Update the text component with the current time
        timeText.text = formattedTime;


        // Position the clock at the top-left corner of the screen
        timeText.rectTransform.anchorMin = new Vector2(0f, 1f);
        timeText.rectTransform.anchorMax = new Vector2(0f, 1f);
        timeText.rectTransform.pivot = new Vector2(0f, 1f);
        timeText.rectTransform.anchoredPosition = new Vector2(10f, -10f); // Adjust the position as desired




    }
}
