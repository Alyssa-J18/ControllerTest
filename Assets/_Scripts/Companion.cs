using UnityEngine;

public class Companion : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 1.5f;
    public Vector2 offset;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
         Vector3 targetPosition = player.position + (Vector3)offset;
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }
}
