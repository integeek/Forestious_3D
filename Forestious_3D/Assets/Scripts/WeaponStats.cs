using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float damage = 5;
    public float attackSpeed = 5;
    public float range = 5;
    public Enemy enemyScript; // Déclarer une variable publique de type Enemy

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet touché a le tag "Enemy"
        if(other.gameObject.CompareTag("Enemy"))
        {
            // Obtenir le composant Enemy de l'objet touché
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();

            // Vérifier si le composant Enemy existe
            if(enemyComponent != null)
            {
                // Infliger des dégâts à l'ennemi en utilisant la variable damage
                enemyComponent.TakeDamage(damage);
            }
        }
    }
}
