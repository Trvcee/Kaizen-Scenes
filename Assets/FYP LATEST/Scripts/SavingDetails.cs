using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class SavingDetails : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;

    // Start is called before the first frame update
    void Start()
    {
        //loginButton.onClick.AddListener(Login);
        //goToRegisterButton.onClick.AddListener(MoveToRegister);
    }

    // Update is called once per frame
    void Login()
    {
        string savedUsername = PlayerPrefs.GetString("SavedUsername", "");
        string savedPassword = PlayerPrefs.GetString("SavedPassword", "");

        if (usernameInput.text.Equals(savedUsername) && passwordInput.text.Equals(savedPassword))
        {
            Debug.Log($"Logging in '{usernameInput.text}'");
            LoadWelcomeScreen();
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
    }

    void MoveToRegister()
    {
        SceneManager.LoadScene("Register");
    }

    void LoadWelcomeScreen()
    {
        SceneManager.LoadScene("WelcomeScreen");
    }

    // Function to save user credentials
    void SaveCredentials()
    {
        PlayerPrefs.SetString("SavedUsername", usernameInput.text);
        PlayerPrefs.SetString("SavedPassword", passwordInput.text);
        PlayerPrefs.Save();
        Debug.Log("Credentials saved locally");
    }
}


