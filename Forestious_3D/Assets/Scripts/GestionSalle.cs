using UnityEngine;

public class GestionSalle : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawner enemySpawner;
    private bool enemiesSpawned = false;
    public GameObject centreObject;
    public GameObject[] trees;
    public GameObject[] doors;
    public GameObject rockPrefab; // Prefab du rocher
    public GameObject flowerPotPrefab; // Prefab du pot de fleurs

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned)
        {
            foreach (GameObject tree in trees)
            {
                tree.SetActive(true);
            }

            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;

            enemySpawner.SpawnEnemies();
            enemiesSpawned = true;

            // Spawn des rochers et des pots de fleurs
            SpawnObstacles();
        }
        else if (other.CompareTag("Player"))
        {
            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;
        }
    }

void SpawnObstacles()
{
    // Nombre aléatoire de rochers à instancier entre 0 et 2
    int rockCount = Random.Range(0, 3); // Le maximum (3) est exclusif, donc cela génère 0, 1 ou 2

    // Instancier les rochers
    for (int i = 0; i < rockCount; i++)
    {
        float xPos = Random.Range(-20f, 20f); // Position X aléatoire
        float zPos = Random.Range(-20f, 20f); // Position Z aléatoire
        Instantiate(rockPrefab, new Vector3(xPos, 0f, zPos), Quaternion.identity);
    }

    // Nombre aléatoire de pots de fleurs à instancier entre 0 et 2
    int flowerPotCount = Random.Range(0, 3); // Le maximum (3) est exclusif, donc cela génère 0, 1 ou 2

    // Instancier les pots de fleurs
    for (int i = 0; i < flowerPotCount; i++)
    {
        float xPos = Random.Range(-20f, 20f); // Position X aléatoire
        float zPos = Random.Range(-20f, 20f); // Position Z aléatoire
        Instantiate(flowerPotPrefab, new Vector3(xPos, 0f, zPos), Quaternion.identity);
    }
}


    void Update()
    {
        if (enemiesSpawned && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
        }
    }
}
