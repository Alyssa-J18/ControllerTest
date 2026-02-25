using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoneyTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the honey pot!");
            // Add additional logic here, e.g., increase score, play sound, etc.
            Destroy(gameObject);
        }
    }


}