using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 20f;
    [SerializeField] private Healthbar _healthbar;
    private static int activeEnemies = 0;
    public float damageAmount = 10f;

    void Start()
    {
       health = maxHealth;
       _healthbar.updateHealthBar(maxHealth, health);
       activeEnemies++;
    }

    private void OnDestroy()
    {
        activeEnemies--;
        CheckEnemiesRemaining();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        _healthbar.updateHealthBar(maxHealth, health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CheckEnemiesRemaining()
    {
        if (activeEnemies <= 0)
        {
            DestroyDoor();
        }
    }

    private void DestroyDoor()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        if (door != null)
        {
            Destroy(door);
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) // Vérifie si le joueur entre en collision avec l'ennemi
    {
        CharacterStats playerStats = other.GetComponent<CharacterStats>();
        if (playerStats != null) // Correction de la comparaison
        {
            playerStats.TakeDamage(damageAmount); // Inflige des dégâts au joueur
        }
    }
}

}
