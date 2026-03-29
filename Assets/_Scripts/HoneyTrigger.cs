using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoneyTrigger : MonoBehaviour
{
public TextMeshProUGUI honeyText;


private void Start()
{
    honeyText = GameObject.FindWithTag("honeyText").GetComponent<TextMeshProUGUI>();
}


private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            GameManager.Instance.AddScore(1);
            honeyText.text = GameManager.Instance.score.ToString();
            Destroy(gameObject);
        }
    }


}