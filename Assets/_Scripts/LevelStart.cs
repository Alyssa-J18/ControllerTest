using UnityEngine;

public class LevelStart : MonoBehaviour
{
    void Start()
    {
        if (CoinTracker.Instance != null)
        {
            CoinTracker.Instance.SnapshotLevelStart();
        }
    }
}