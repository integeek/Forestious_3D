using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int minEnemies = 2;
    public int maxEnemies = 4;
    public float spawnRadius = 5f;
    public LayerMask groundLayer;
    public GameObject centerObject;

    void Start()
    {
    }

    public void SpawnEnemies()
    {
        int numEnemies = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 spawnPosition = GenerateSpawnPosition();

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 centerPosition = centerObject.transform.position;

        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(randomPoint.x, 1.755f, randomPoint.y) + centerPosition;

        RaycastHit hit;
        if (Physics.Raycast(spawnPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            spawnPosition = hit.point;
        }

        return spawnPosition;
    }
}
