using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Bird must have tag "Player"
        {
            FindObjectOfType<ScoreManager>().AddScore(1);
        }
    }
}
