using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à spawner
    public int minEnemies = 2; // Le nombre minimum d'ennemis à spawner
    public int maxEnemies = 4; // Le nombre maximum d'ennemis à spawner

    void Start()
    {
        // Calculer un nombre aléatoire d'ennemis à spawner entre minEnemies et maxEnemies
        int numEnemies = Random.Range(minEnemies, maxEnemies + 1);

        // Boucler pour instancier chaque ennemi
        for (int i = 0; i < numEnemies; i++)
        {
            // Générer une position aléatoire sur le plan
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 1.755f, Random.Range(-10f, 10f));

            // Instancier l'ennemi à la position générée
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
