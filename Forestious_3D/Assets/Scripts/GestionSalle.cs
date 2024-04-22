using UnityEngine;

public class GestionSalle : MonoBehaviour
{
    public Camera mainCamera; // Référence à la caméra à déplacer  
    public EnemySpawner enemySpawner; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que le joueur a le tag "Player"
        {
            Vector3 newPos = new Vector3(7.21f, 21f, 17.65f);
            mainCamera.transform.position = newPos;
            enemySpawner.SpawnEnemies();

        }
    }
}
