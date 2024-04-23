using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraDepart;
    public GameObject camera1;
    public EnemySpawner enemySpawner;

    private bool enemiesSpawned = false; // Indique si les ennemis ont déjà été spawnés

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned) 
        {
            cameraDepart.SetActive(false);
            camera1.SetActive(true);
            enemySpawner.SpawnEnemies();
            enemiesSpawned = true; // Marque que les ennemis ont été spawnés

            // Vous pouvez ajouter d'autres actions pour le changement de caméra ici
        }
        else if (other.CompareTag("Player") && enemiesSpawned)
        {
            // Actions à effectuer lorsque le joueur rentre dans le trigger après que les ennemis ont été spawnés
            cameraDepart.SetActive(false);
            camera1.SetActive(true);

            // Vous pouvez ajouter d'autres actions pour le changement de caméra ici
        }
    }
}
