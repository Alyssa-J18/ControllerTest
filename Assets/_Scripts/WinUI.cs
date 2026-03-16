using UnityEngine;

public class WinUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
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
