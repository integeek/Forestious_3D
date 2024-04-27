using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;

    public EnemySpawner enemySpawner;
    public GameObject[] trees;
    public GameObject[] doors;
    public GameObject[] powerUps;
    private bool enemiesSpawned = false;
    public GameObject centreObject;

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
            mainCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Rotation à (90, 0, 0)
            enemySpawner.SpawnEnemies();
            enemiesSpawned = true;

        }
        else if (other.CompareTag("Player") && enemiesSpawned)
        {
            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;
            mainCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Rotation à (90, 0, 0)

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
