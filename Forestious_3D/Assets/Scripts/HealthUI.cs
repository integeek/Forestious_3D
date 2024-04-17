using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public CharacterStats characterStats;
    public GameObject heartPrefab;
    public Transform heartsParent;
    public float heartSpacing = 50f; // Espacement horizontal entre les cœurs

    void Start()
    {
        Vector3 startPosition = new Vector3(-26.7f, 16.3f, 0f); // Position du premier cœur

        for (int i = 0; i < characterStats.health; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsParent);
            heart.transform.localPosition = startPosition + new Vector3(i * heartSpacing, 0, 0); // Ajuste la position en fonction de l'index
        }
    }
}
