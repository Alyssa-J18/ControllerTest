using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoneyTrigger : MonoBehaviour
{
public TextMeshProUGUI honeyText;
public AudioClip coinClip;
private AudioSource audioSource;

void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

void OnEnable()
{
    honeyText.text = CoinTracker.Instance.Honeycollected.ToString();
}


private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
             AudioSource.PlayClipAtPoint(coinClip, transform.position);
            if (CoinTracker.Instance != null)
            {
                CoinTracker.Instance.AddHoney(1);
                honeyText.text = CoinTracker.Instance.Honeycollected.ToString();
            }
            Destroy(gameObject);
        }
    }
}