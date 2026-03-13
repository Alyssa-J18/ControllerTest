using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public Rigidbody2D rb;
    public float jumpPower = 10f;
    
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.6f, 0.2f);
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
    float moveInput = 0;

    if (Input.GetKey(KeyCode.RightArrow))
        moveInput = 1;

    if (Input.GetKey(KeyCode.LeftArrow))
        moveInput = -1;

    if (Input.GetKey(KeyCode.D))
        moveInput = 1;

    if (Input.GetKey(KeyCode.A))
        moveInput = -1;

    rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

    if (jumpsRemaining > 0 && Input.GetKeyDown(KeyCode.Space))
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        jumpsRemaining--;
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
