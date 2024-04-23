using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCsystem : MonoBehaviour
{
    bool player_detection = false;
    public GameObject canva;
    public GameObject d_template;

    void Update()
    {
        if(player_detection && Input.GetKeyDown(KeyCode.F) && (!Movement.dialogue))
        {
            canva.SetActive(true);
            Movement.dialogue = true;
            NewDialogue("Hello, fortunately you are here, we need you. Our forest is invaded by monsters and our most precious artifact is stuck in the middle of the forest");
            NewDialogue("To get there, you have to cross the forest but the deeper you go, the more powerful the monsters become. On your way, you will find objects that can help you");
            NewDialogue("To start, choose between the sword or the axe. The sword does big targeted damage while the axe does more area damage.");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

void NewDialogue(string text)
{
    GameObject templateClone = Instantiate(d_template, Vector3.zero, Quaternion.identity);
    templateClone.transform.SetParent(canva.transform, false);
    
    // Placer le dialogue légèrement au-dessus du bas de l'écran en ajustant sa position Y
    RectTransform templateRect = templateClone.GetComponent<RectTransform>();
    Vector2 newPosition = templateRect.anchoredPosition;
    newPosition.y = -templateRect.sizeDelta.y * canva.transform.localScale.y * 0.1f; // Déplacement vers le haut de 10% de la taille du dialogue
    templateRect.anchoredPosition = newPosition;
    
    templateClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }
}
