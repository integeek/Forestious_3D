using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    int index = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && transform.childCount > 1)
        {
            if (Movement.dialogue)
            {
                // Désactiver le dialogue précédent
                transform.GetChild(index - 1).gameObject.SetActive(false);

                // Activer le dialogue suivant
                transform.GetChild(index).gameObject.SetActive(true);
                index++;

                // Réinitialiser l'index si nécessaire
                if (transform.childCount == index)
                {
                    index = 2;
                    Movement.dialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
