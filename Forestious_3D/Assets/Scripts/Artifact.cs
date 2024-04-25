using UnityEngine;

public class Artifact : MonoBehaviour
{
    public GameObject ArtifactPlayer;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
 
            ArtifactPlayer.SetActive(true);
            Destroy(gameObject);
        }
    }
}
