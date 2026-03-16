using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        gameObject.SetActive(false);
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