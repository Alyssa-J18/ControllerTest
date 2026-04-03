using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI honeyText;

    void start()
    {
        honeyText.text = CoinTracker.Instance.Honeycollected.ToString();
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        CoinTracker.Instance.resetCoins();
    }

    

    public void Quit()
    {
        Application.Quit();
    }

    

    

}
