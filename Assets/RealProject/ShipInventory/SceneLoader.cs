using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeScene()
    {
        if(currentSceneIndex == 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(1);
    }
}
