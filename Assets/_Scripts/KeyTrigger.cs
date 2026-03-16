using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyTrigger : MonoBehaviour
{
    public GameObject door;
  
    
    void Start()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has triggered the key!");
            // Add additional logic here, e.g., increase score, play sound, etc.
            door.SetActive(true);
            Destroy(gameObject);
        }

    }



}