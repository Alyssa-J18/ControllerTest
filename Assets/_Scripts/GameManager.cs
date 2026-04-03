using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A simple Singleton GameManager that persists across scenes and tracks score + lives.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public int score = 0;

    void Start()
    {
       
    }

    void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
}

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
        // In a real project, you might raise an event here to update UI.
    }

    

    public void ResetGame()
    {
        score = 0;
        CoinTracker.Instance.RestoreLevelStart();
        Debug.Log("Game reset.");
    }

    public void RestartLevel()
    {
        if (CoinTracker.Instance != null)
        {
            CoinTracker.Instance.RestoreLevelStart();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
