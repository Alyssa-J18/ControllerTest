using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI honeyText;

    void Start()
    {
        honeyText.text = GameManager.Instance.score.ToString();
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        GameManager.Instance.score = 0;
    }

    

    public void Quit()
    {
        Application.Quit();
    }

    

    

}
