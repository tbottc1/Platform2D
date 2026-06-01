using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;

    Rigidbody2D rb;

    float jumpForce = 7f; 
    int maxJumps = 2;
    int jumpsRemaining;

    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f;
            spriteRenderer.flipX = false;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f;
            spriteRenderer.flipX = true;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpsRemaining--;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            RestartLevel();
        }

        if(other.CompareTag("Goal"))
        {
            GameSystem gameSystem = FindAnyObjectByType<GameSystem>();
            if (gameSystem.CanWin())
            {
                gameSystem.WinScreen();
            }
        }

        if(other.CompareTag("Enemy"))
        {
            RestartLevel();
        }

        if(other.CompareTag("Collectible"))
        {
            FindAnyObjectByType<GameSystem>().AddCollectible();
            Destroy(other.gameObject);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
