using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public CharacterStats characterStats;
    public WeaponStats weaponStats;
    public float bonusSpeed = 15f;
    public float bonusDamage = 5f;

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

            Destroy(gameObject); // Détruit le power-up une fois qu'il a été récupéré par le joueur
        }
    }
}
