using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;
    private CharacterStats characterStats; // Reference to CharacterStats

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterStats = GetComponent<CharacterStats>(); // Get reference to CharacterStats from the same GameObject
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //characterController.Move(move * Time.deltaTime * characterStats.moveSpeed);

        // Déplacer le personnage en utilisant SimpleMove
        characterController.SimpleMove(move * characterStats.moveSpeed);

        // Check if there is movement (magnitude of move vector is not zero)
        if (move.magnitude > 0)
        {
            // Calculate the rotation to look at the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(move);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * characterStats.rotationSpeed);
        }
    }
}
