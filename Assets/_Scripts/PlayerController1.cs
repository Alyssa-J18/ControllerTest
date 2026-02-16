using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public float jumpHeight = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // Get the current position of the player
            Vector2 curPos = gameObject.transform.position;

            // Get new position by adding to the x coordinate
            Vector2 newPos = new Vector2(curPos.x + Time.deltaTime * speed, curPos.y);

            // Update the player's position
            gameObject.transform.position = newPos;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // Get the current position of the player
            Vector2 curPos = gameObject.transform.position;

            // Get new position by subtracting from the x coordinate
            Vector2 newPos = new Vector2(curPos.x - Time.deltaTime * speed, curPos.y);

            // Update the player's position
            gameObject.transform.position = newPos;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            // Get the current position of the player
            Vector2 curPos = gameObject.transform.position;

            // Get new position by subtracting from the x coordinate
            Vector2 newPos = new Vector2(curPos.x, curPos.y + jumpHeight);

            // Update the player's position
            gameObject.transform.position = newPos;
        }

        
    }
}
