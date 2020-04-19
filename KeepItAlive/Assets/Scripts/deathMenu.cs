using UnityEngine.SceneManagement;
using UnityEngine;

public class deathMenu : MonoBehaviour
{
    public void RestartButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
