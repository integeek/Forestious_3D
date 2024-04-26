using UnityEngine;

public class CamDepart : MonoBehaviour
{
    public Camera cameraDepart;
    public Camera cameraGame;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraDepart.enabled = true;
            cameraGame.enabled = false;
        }
    }
}
