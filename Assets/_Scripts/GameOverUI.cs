using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 0f;
        GameManager.Instance.RestartLevel();
    }

    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }

    public void Quit()
    {
        GameManager.Instance.QuitGame();
    }
}