using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject aboutMenuUI;
    public GameObject mainMenuUI;

    private AudioManager aM;

    private void Start()
    { 
        aboutMenuUI.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AboutButton()
    {
        aboutMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void YouTubeButton()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCqnbjWUiUzzyo8uyCkN05Fw?view_as=subscriber");
    }

    public void DiscordButton()
    {
        Application.OpenURL("https://discord.gg/7X8S9wK");
    }

    public void backButton()
    {
        aboutMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
}
