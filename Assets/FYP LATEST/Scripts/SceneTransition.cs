    using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName = "YourTargetSceneName"; // Specify your target scene name here

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
