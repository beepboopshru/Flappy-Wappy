using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // How fast the pipe moves left
    public float destroyX = -10f; // X position at which to destroy the pipe

    void Update()
    {
        // Move the pipe left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Destroy when off-screen
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
