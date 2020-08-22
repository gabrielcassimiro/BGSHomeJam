using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button creditsButton = null;
    [SerializeField] private Button quitButton = null;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        creditsButton.onClick.AddListener(Credits);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("PrototypeScene");
    }

    private void Credits()
    {
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}