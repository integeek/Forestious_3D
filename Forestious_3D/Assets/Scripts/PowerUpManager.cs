using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public WeaponStats weaponStats;
    public AxeStats axeStats;
    public GameObject[] weapons;
    public float bonusSpeed = 5f;
    public float bonusDamage = 5f;
    public float bonusHealth = 15f;
    public float bonusRange = 5f;


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
                axeStats.damage += bonusDamage;
            }
            else if (gameObject.CompareTag("HealthUp"))
            {
                characterStats.Heal(bonusHealth);
            }
            else if (gameObject.CompareTag("RangeUp"))
            {
                foreach (GameObject weapon in weapons)
                {
                Vector3 currentScale = weapon.transform.localScale;
                currentScale.z += bonusRange;
                weapon.transform.localScale = currentScale;
                }
            }


            Destroy(gameObject);
        }
    }
}
