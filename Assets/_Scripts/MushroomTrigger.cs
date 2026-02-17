using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MushroomTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the mushroom!");
            // Add additional logic here, e.g., increase score, play sound, etc.
            Destroy(gameObject);
        }
    }


}