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
    public int lives = 3;

    [Header("Scene Settings")]
    [Tooltip("Optional: set a scene name to load on game over.")]
    public string gameOverSceneName = "GameOver";

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this duplicate.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance and persist across scenes.
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
        // In a real project, you might raise an event here to update UI.
    }

    public void LoseLife(int amount = 1)
    {
        lives -= amount;
        Debug.Log($"Lives: {lives}");

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void ResetGame()
    {
        score = 0;
        lives = 3;
        Debug.Log("Game reset.");
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
