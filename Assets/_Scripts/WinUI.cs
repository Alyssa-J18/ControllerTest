using UnityEngine;

public class WinUI : MonoBehaviour
{
    public GameObject container;
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
