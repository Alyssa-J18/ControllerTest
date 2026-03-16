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

    [Header("Scene Settings")]
    [Tooltip("Optional: set a scene name to load on game over.")]

    public GameObject objectToAppear; 
    private bool isCollected = false;



    void Start()
    {
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(false);
        }
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

    public void ItemCollected()
    {
        if (!isCollected)
        {
            isCollected = true;
            if (objectToAppear != null)
            {
                objectToAppear.SetActive(true);
            }
        }
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
        Debug.Log("Game reset.");
    }

    public void RestartLevel()
    {
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
