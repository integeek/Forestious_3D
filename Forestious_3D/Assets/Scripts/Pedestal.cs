using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public GameObject pedestalSword;
    public GameObject pedestalAxe;
    public GameObject axe;
    public GameObject sword;
    public GameObject door;
    public GameObject hexagone1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("PDS")) 
            {
                Destroy(pedestalAxe);
                Destroy(pedestalSword);
                sword.SetActive(true);
                Destroy(door);
                hexagone1.SetActive(true);

            }
            else if (gameObject.CompareTag("PDA"))
            {
                Destroy(pedestalAxe);
                Destroy(pedestalSword);
                axe.SetActive(true);
                Destroy(door);
                hexagone1.SetActive(true);

            }
        }
    }
}
