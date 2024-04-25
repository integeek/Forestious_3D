using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public WeaponStats weaponStats;
    public float bonusSpeed = 5f;
    public float bonusDamage = 5f;
    public float bonusHealth = 15f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("SpeedUp"))
            {
                characterStats.moveSpeed += bonusSpeed;
            }
            else if (gameObject.CompareTag("DamageUp"))
            {
                weaponStats.damage += bonusDamage;
            }
            else if (gameObject.CompareTag("HealthUp"))
            {
                characterStats.Heal(bonusHealth);
            }

            Destroy(gameObject);
        }
    }
}
