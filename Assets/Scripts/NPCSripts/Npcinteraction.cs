using System.Collections.Generic;
using UnityEngine;

public class Npcinteraction : MonoBehaviour
{
    public GameObject interactionUI; // UI z informacj� o klikni�ciu E
    private bool isPlayerLooking = false;

    public List<string> npcDialog; // Linie dialogowe przypisane do NPC

    void Start()
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false); // Ukryj UI na starcie
        }
    }

    void Update()
    {
        if (isPlayerLooking && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();
        }
    }

    void StartConversation()
    {
        if (npcDialog != null && npcDialog.Count > 0)
        {
            DialogManager.Instance.StartDialog(npcDialog); // Rozpocznij dialog
        }
    }

    private void OnMouseEnter()
    {
        isPlayerLooking = true;
        if (interactionUI != null)
        {
            interactionUI.SetActive(true); // Poka� UI informuj�ce o mo�liwo�ci rozmowy
        }
    }

    private void OnMouseExit()
    {
        isPlayerLooking = false;
        if (interactionUI != null)
        {
            interactionUI.SetActive(false); // Ukryj UI, gdy myszka opu�ci NPC
        }
    }
}
