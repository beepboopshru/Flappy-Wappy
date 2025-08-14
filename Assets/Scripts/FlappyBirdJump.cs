using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FlappyBirdJump : MonoBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGameOver = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        rb.gravityScale = 1.5f;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Time.timeScale = 1f; // Unpause before reload
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(0, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions if already game over
        if (isGameOver) return;

        Debug.Log("Game Over! Collided with: " + collision.gameObject.name);

        isGameOver = true;

        // Stop bird movement & physics
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;

        // Show Game Over UI and pause the game
        StartAndRestartMenu menu = FindObjectOfType<StartAndRestartMenu>();
        if (menu != null)
        {
            menu.ShowGameOverMenu();
        }
        else
        {
            // Fallback: pause if no menu is found
            Time.timeScale = 0f;
        }
    }
}
