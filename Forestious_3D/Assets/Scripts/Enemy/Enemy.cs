using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 20f;
    [SerializeField] private Healthbar _healthbar;
    private static int activeEnemies = 0;
    public float damageAmount = 10f;
    public AudioSource audioSource;

    void Start()
    {
       health = maxHealth;
       _healthbar.updateHealthBar(maxHealth, health);
       activeEnemies++;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        _healthbar.updateHealthBar(maxHealth, health);

        if (health <= 0)
        {
            audioSource.Play();
            Destroy(gameObject);
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        CharacterStats playerStats = other.GetComponent<CharacterStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(damageAmount);
        }
    }
}

}
