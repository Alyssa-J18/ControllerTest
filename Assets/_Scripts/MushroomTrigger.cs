using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MushroomTrigger : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject painManager;
    private int score = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the mushroom!");

            score = int.Parse(scoreText.text);
            score = score + 1;
            scoreText.text = score.ToString();

            painManager.GetComponent<AudioSource>().Play();
            // Add additional logic here, e.g., increase score, play sound, etc.
            Destroy(gameObject);
        }
    }


}
