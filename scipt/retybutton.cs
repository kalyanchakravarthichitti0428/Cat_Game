using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("1");
    }
}
