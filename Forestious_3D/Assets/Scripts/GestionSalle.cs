using UnityEngine;

public class GestionSalle : MonoBehaviour
{
    public Camera mainCamera;
    public EnemySpawner enemySpawner;
    private bool enemiesSpawned = false;
    public GameObject centreObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned)
        {
  
            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;

            enemySpawner.SpawnEnemies();
            enemiesSpawned = true;
        }
        else if (other.CompareTag("Player"))
        {
            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;
        }
    }
}
