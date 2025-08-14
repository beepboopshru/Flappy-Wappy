using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bird; // Drag your Bird GameObject here in Inspector
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (bird == null) return;

        // Follow bird's X position only
        Vector3 targetPosition = transform.position;
        targetPosition.x = bird.position.x;
        
        // Smooth movement
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
