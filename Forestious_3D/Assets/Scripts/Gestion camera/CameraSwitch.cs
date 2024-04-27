using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraDepart;
    public GameObject camera1;
    public EnemySpawner enemySpawner;
    public GameObject[] trees;
    public GameObject[] doors;
    public GameObject[] powerUps;
    private bool enemiesSpawned = false;

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enemiesSpawned) 
        {
            foreach (GameObject tree in trees)
            {
                tree.SetActive(true);
            }
            cameraDepart.SetActive(false);
            camera1.SetActive(true);
            enemySpawner.SpawnEnemies();
            enemiesSpawned = true;

        }
        else if (other.CompareTag("Player") && enemiesSpawned)
        {
            cameraDepart.SetActive(false);
            camera1.SetActive(true);

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
            foreach (GameObject powerUp in powerUps)
            {
                powerUp.SetActive(true);
            }
        }
    }
}
