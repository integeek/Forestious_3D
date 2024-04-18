using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 20f;
    [SerializeField] private Healthbar _healthbar;

    void Start()
    {
       health = maxHealth;
       _healthbar.updateHealthBar(maxHealth, health);
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
}
