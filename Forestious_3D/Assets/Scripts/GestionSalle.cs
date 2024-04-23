using UnityEngine;

public class GestionSalle : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawner enemySpawner;
    private bool enemiesSpawned = false; // Booléen pour garder une trace du statut de spawn des ennemis
    public GameObject centreObject; // Le gameObject centre défini dans l'éditeur Unity

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned) // Vérifiez si les ennemis n'ont pas encore été spawnés
        {
            // Obtenez les coordonnées du gameObject centre
            Vector3 centrePosition = centreObject.transform.position;

            // Mettez la caméra 21 au-dessus du gameObject centre
            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;

            // Spawn les ennemis
            enemySpawner.SpawnEnemies();
            enemiesSpawned = true; // Mettez à jour le statut de spawn des ennemis
        }
        else if (other.CompareTag("Player")) // Si les ennemis ont déjà été spawnés, changez simplement la position de la caméra
        {
            // Obtenez les coordonnées du gameObject centre
            Vector3 centrePosition = centreObject.transform.position;

            // Mettez la caméra 21 au-dessus du gameObject centre
            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;
        }
    }
}
