using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int minEnemies = 2;
    public int maxEnemies = 4;
    public LayerMask groundLayer;

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
        Vector3 spawnPosition = Vector3.zero;
        bool foundValidPosition = false;

        while (!foundValidPosition)
        {
            spawnPosition = new Vector3(Random.Range(-10f, 10f), 1.755f, Random.Range(-10f, 10f));

            RaycastHit hit;
            if (Physics.Raycast(spawnPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                foundValidPosition = true;
            }
        }

        return spawnPosition;
    }
}
