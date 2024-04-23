using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float rotationSpeed = 25;
    public float moveSpeed = 7.5f;
    [SerializeField] float health, maxHealth = 30f;
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

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
