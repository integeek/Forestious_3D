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
        characterController.Move(move * Time.deltaTime * characterStats.moveSpeed);
    }
}
