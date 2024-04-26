using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCsystem : MonoBehaviour
{
    bool playerDetection = false;
    public GameObject canvas;
    public GameObject dialogueTemplate;

    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.F) && (!Movement.dialogue))
        {
            if (HasArtifact())
            {
                canvas.SetActive(true);
                Movement.dialogue = true;
                NewDialogue("You have the artifact! Thank you for bringing it back!");
                canvas.transform.GetChild(1).gameObject.SetActive(true);

            }
            else
            {
                // Lancer le dialogue standard
                canvas.SetActive(true);
                Movement.dialogue = true;
                NewDialogue("Hello, fortunately you are here, we need you. Our forest is invaded by monsters and our most precious artifact is stuck in the middle of the forest");
                NewDialogue("To get there, you have to cross the forest but the deeper you go, the more powerful the monsters become. On your way, you will find objects that can help you");
                NewDialogue("To start, choose between the sword or the axe. The sword does big targeted damage while the axe does more area damage.");
                canvas.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    void NewDialogue(string text)
    {
        GameObject templateClone = Instantiate(dialogueTemplate, Vector3.zero, Quaternion.identity);
        templateClone.transform.SetParent(canvas.transform, false);

        RectTransform templateRect = templateClone.GetComponent<RectTransform>();
        Vector2 newPosition = templateRect.anchoredPosition;
        newPosition.y = -templateRect.sizeDelta.y * canvas.transform.localScale.y * 0.1f;
        templateRect.anchoredPosition = newPosition;

        templateClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    bool HasArtifact()
    {
        GameObject[] artifacts = GameObject.FindGameObjectsWithTag("Artifact");
        return (artifacts.Length > 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerDetection = false;
    }
}
