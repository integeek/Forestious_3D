using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Aucun objet avec le tag 'Player' n'a été trouvé.");
        }
    }
}
