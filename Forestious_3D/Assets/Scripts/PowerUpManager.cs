using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public CharacterStats characterStats;
    public WeaponStats weaponStats;
    public float bonusSpeed = 5f;
    public float bonusDamage = 5f;
    public float bonusHealth = 1f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que le joueur a le tag "Player"
        {
            if (gameObject.CompareTag("SpeedUp")) // Si le power-up a le tag "SpeedUp"
            {
                characterStats.moveSpeed += bonusSpeed; // Ajoute le bonus de vitesse au joueur
            }
            else if (gameObject.CompareTag("DamageUp")) // Si le power-up a le tag "DamageUp"
            {
                weaponStats.damage += bonusDamage; // Augmente les dégâts de l'arme du joueur
            }
            else if (gameObject.CompareTag("HealthUp")) // Si le power-up a le tag "HealthUp"
            {
                characterStats.health += bonusHealth; // Augmente la santé du joueur
            }

            Destroy(gameObject); // Détruit le power-up une fois qu'il a été récupéré par le joueur
        }
    }
}
