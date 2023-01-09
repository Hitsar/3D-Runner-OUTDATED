using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
