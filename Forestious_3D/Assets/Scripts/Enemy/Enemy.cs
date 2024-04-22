using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 20f;
    [SerializeField] private Healthbar _healthbar;
    private static int activeEnemies = 0; // Variable statique pour compter les ennemis actifs

    void Start()
    {
       health = maxHealth;
       _healthbar.updateHealthBar(maxHealth, health);
       activeEnemies++; // Incrémente le compteur d'ennemis actifs lorsque cet ennemi est créé
    }

    private void OnDestroy()
    {
        activeEnemies--; // Décrémente le compteur d'ennemis actifs lorsque cet ennemi est détruit
        CheckEnemiesRemaining(); // Vérifie s'il reste d'autres ennemis dans la salle
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
            // Si aucun ennemi actif n'est présent, détruisez la porte
            DestroyDoor();
        }
    }

    private void DestroyDoor()
    {
        // Code pour détruire la porte
        // Par exemple :
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        if (door != null)
        {
            Destroy(door);
        }
    }
}
