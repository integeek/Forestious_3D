using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à spawner
    public int minEnemies = 2; // Le nombre minimum d'ennemis à spawner
    public int maxEnemies = 4; // Le nombre maximum d'ennemis à spawner
    public LayerMask groundLayer; // Le layer du sol

    void Start()
    {
        // Calculer un nombre aléatoire d'ennemis à spawner entre minEnemies et maxEnemies
        int numEnemies = Random.Range(minEnemies, maxEnemies + 1);

        // Boucler pour instancier chaque ennemi
        for (int i = 0; i < numEnemies; i++)
        {
            // Générer une position aléatoire sur le plan
            Vector3 spawnPosition = GenerateSpawnPosition();

            // Instancier l'ennemi à la position générée
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        bool foundValidPosition = false;

        // Tant qu'une position valide n'est pas trouvée, continuer à en générer une
        while (!foundValidPosition)
        {
            // Générer une position aléatoire sur le plan
            spawnPosition = new Vector3(Random.Range(-10f, 10f), 1.755f, Random.Range(-10f, 10f));

            // Lancer un rayon vers le bas à partir de la position générée pour vérifier s'il touche le sol
            RaycastHit hit;
            if (Physics.Raycast(spawnPosition, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                // Si le rayon touche le sol, la position est valide
                foundValidPosition = true;
            }
        }

        return spawnPosition;
    }
}
