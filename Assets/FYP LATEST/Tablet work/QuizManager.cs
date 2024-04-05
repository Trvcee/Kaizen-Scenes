using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject correctAnswerObject;
    public GameObject wrongAnswerObject;
    public GameObject questionObject;

    public TextMeshProUGUI scoreText;

    int score = 0;

    void Start()
    {
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        // Display your question logic here
        // For example:
        questionObject.GetComponent<TextMeshProUGUI>().text = "What is the capital of France?";
        correctAnswerObject.GetComponent<Button>().onClick.AddListener(CorrectAnswer);
        wrongAnswerObject.GetComponent<Button>().onClick.AddListener(WrongAnswer);
    }

    void CorrectAnswer()
    {
        // Called when the correct answer is selected
        score += 1;
        Debug.Log("Correct! Current Score: " + score);
        DisplayQuestion();
    }

    void WrongAnswer()
    {
        // Called when the wrong answer is selected
        Debug.Log("Wrong! Current Score: " + score);
        DisplayQuestion();
    }

    void ShowScore()
    {
        // Display the final score
        scoreText.text = "Final Score: " + score;
        Debug.Log("Final Score: " + score);
    }
}
