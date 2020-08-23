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
        GameController.Instance.StartGame();
        Destroy(gameObject);
    }

    private void Credits()
    {
        GameController.Instance.creditsImage.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}