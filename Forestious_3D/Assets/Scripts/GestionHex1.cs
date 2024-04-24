using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionHex1 : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject centreObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 centrePosition = centreObject.transform.position;

            Vector3 newPos = new Vector3(centrePosition.x, centrePosition.y + 21f, centrePosition.z);
            mainCamera.transform.position = newPos;

        }
    }
}
