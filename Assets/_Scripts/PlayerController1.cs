using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D rb;
    public float jumpPower = 10f;
    
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    public int maxJumps = 2;
    int jumpsRemaining;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GroundCheck();

        if(transform.position.y < -10)
        {
            Die();
        }
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
    if(jumpsRemaining > 0)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            jumpsRemaining--;
        }
    }
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
        
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    
}
