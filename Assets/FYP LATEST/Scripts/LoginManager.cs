using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameInputField;
    [SerializeField]
    private TMP_InputField employeeIDField;

    [SerializeField]
    private TMP_Text errorText; // Reference to the UI Text component to display error messages

    [SerializeField]
    private string sceneToLoad; // Name of the scene to transition to

    private void Start()
    {
        // Add listeners to input fields for detecting changes
        nameInputField.onValueChanged.AddListener(OnInputChanged);
        employeeIDField.onValueChanged.AddListener(OnInputChanged);
    }

    public void OnSubmitGuestLogin()
    {
        Debug.Log("Login Successful");
        LoadScene();
    }

    public void OnSubmitLogin()
    {
        string fullName = nameInputField.text;
        string employeeID = employeeIDField.text;

        string loginCheckMessage = CheckLogInInfo(fullName, employeeID);

        if (string.IsNullOrEmpty(loginCheckMessage))
        {
            Debug.Log("Login Successful");
            errorText.text = ""; // Clear any previous error messages
            LoadScene();
        }
        else
        {
            Debug.LogError("Error: " + loginCheckMessage);
            errorText.text = loginCheckMessage; // Display error message on the HUD
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not specified.");
        }
    }

    private string CheckLogInInfo(string fullName, string employeeID)
    {
        if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(employeeID))
        {
            return "Please enter Full Name and Employee ID";
        }
        else if (string.IsNullOrEmpty(fullName))
        {
            return "Please enter Full Name";
        }
        else if (string.IsNullOrEmpty(employeeID))
        {
            return "Please enter Employee ID";
        }
        else
        {
            return "";
        }
    }

    private void OnInputChanged(string text)
    {
        if (string.IsNullOrEmpty(nameInputField.text) && string.IsNullOrEmpty(employeeIDField.text))
        {
            errorText.text = "Please enter Full Name and Employee ID";
        }
        else if (string.IsNullOrEmpty(nameInputField.text))
        {
            errorText.text = "Please enter Full Name";
        }
        else if (string.IsNullOrEmpty(employeeIDField.text))
        {
            errorText.text = "Please enter Employee ID";
        }
        else
        {
            errorText.text = "";
        }
    }
}
