using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    public float jumpPower = 10f;
    
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.6f, 0.2f);
    public LayerMask groundLayer;
    public int maxJumps = 2;
    int jumpsRemaining;
    
    public int maxHealth = 3;
    public int health = 3;
    public Image healthImage;
    private SpriteRenderer spriteRenderer;

    public float iFrameDuration = 1f;
    private bool isInvisible = false;

    public int honey;

    public GameObject gameOverScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpsRemaining = maxJumps;
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        healthImage.fillAmount = (float)health / maxHealth;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            if (isInvisible) return;
            health -= 1;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            StartCoroutine(InvincibilityFrames());

            if (health <= 0)
            {
                Die();
            }
        }
    }


    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator InvincibilityFrames()
    {
        isInvisible = true;
        float elapsed = 0f;
        while (elapsed < iFrameDuration)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.3f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
            yield return new WaitForSeconds(0.1f);

            elapsed += 0.2f;
        }
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        isInvisible = false;
    }

    public void Die()
    {
        gameOverScreen.SetActive(true);
    }
}
