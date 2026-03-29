using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlStart : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}