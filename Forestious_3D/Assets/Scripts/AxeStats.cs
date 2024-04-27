using UnityEngine;

public class AxeStats : MonoBehaviour
{
    public float damage = 5;
    public float attackSpeed = 5;
    public float range = 5;
    public Enemy enemyScript;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();

            if(enemyComponent != null)
            {
                enemyComponent.TakeDamage(damage);
            }
        }
    }
}
