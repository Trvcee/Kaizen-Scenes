using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Specify the scene to transition to when pressing "2" in the Unity Editor
    public string transitionSceneName = "YourTransitionSceneName";

    private void Update()
    {
        // Restart scene when pressing "1"
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RestartScene();
        }

        // Transition to a specified scene when pressing "2"
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Transitioning to scene: " + transitionSceneName);
            TransitionToScene(transitionSceneName);
        }
    }

    private void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TransitionToScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}

