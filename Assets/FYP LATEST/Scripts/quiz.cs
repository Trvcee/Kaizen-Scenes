using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quiz : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public Button correctOption;
        public Button wrongOption;
        public Button submitButton;
        public int score;
    }

    public Question question1;
    public Question question2;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Add listeners to the buttons for the first question
        question1.correctOption.onClick.AddListener(() => OnOptionClicked(question1, true));
        question1.wrongOption.onClick.AddListener(() => OnOptionClicked(question1, false));
        question1.submitButton.onClick.AddListener(() => OnSubmitButtonClicked(question1));

        // Add listeners to the buttons for the second question
        question2.correctOption.onClick.AddListener(() => OnOptionClicked(question2, true));
        question2.wrongOption.onClick.AddListener(() => OnOptionClicked(question2, false));
        question2.submitButton.onClick.AddListener(() => OnSubmitButtonClicked(question2));
    }

    private void UpdateScoreText()
    {
        // Update the TextMeshProUGUI text with the current total score
        scoreText.text = "Total Score: " + (question1.score + question2.score);
    }

    private void OnOptionClicked(Question question, bool isCorrectOption)
    {
        // Update the score based on whether the correct option is clicked
        question.score = isCorrectOption ? 1 : 0;
    }

    private void OnSubmitButtonClicked(Question question)
    {
        // Additional logic for the submit button if needed
        // This can include checking other conditions before updating the score

        // Update the TextMeshProUGUI text after each question is submitted
        UpdateScoreText();
    }
}
