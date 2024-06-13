using UnityEngine;

public class CamDepart : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 initialPosition = new Vector3(-18f, 12f, -10f);
    public Vector3 initialRotation = new Vector3(37.74f, 0f, 0f); // Rotation initiale

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCamera.transform.position = initialPosition;
            mainCamera.transform.rotation = Quaternion.Euler(initialRotation);
        }
    }
}
