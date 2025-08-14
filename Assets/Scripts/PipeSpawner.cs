using UnityEngine;

public class PipeSpawnerAndMover : MonoBehaviour
{
    [Header("Pipe Settings")]
    public GameObject pipePrefab;   // Prefab with BoxCollider2D
    public float moveSpeed = 2f;
    public float destroyX = -10f;

    [Header("Spawn Settings")]
    public float spawnRate = 2f;
    public float minY = -1f;
    public float maxY = 3f;
    public float spawnX = 10f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        // Parent the pipe under the spawner so it's organized
        newPipe.transform.parent = transform;
    }

    void LateUpdate()
    {
        // Move all pipes that are children of this spawner
        foreach (Transform pipe in transform)
        {
            pipe.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (pipe.position.x < destroyX)
            {
                Destroy(pipe.gameObject);
            }
        }
    }
}
