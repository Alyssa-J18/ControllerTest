using UnityEngine;

public class CoinTracker : MonoBehaviour
{
    public static CoinTracker Instance;
    public int Honeycollected = 0;
    
    private int levelStartHoney = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void AddHoney(int amount)
    {
        Honeycollected += amount;

    }

    public void resetCoins()
    {
        Honeycollected = 0;
    }

    public void SnapshotLevelStart()
    {
        levelStartHoney = Honeycollected;
    }


    public void RestoreLevelStart()
    {
        Honeycollected = levelStartHoney;
    }
}
