using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject dialogueUI; // UI dialogowe
    public GameObject player;
    public float interactionDistance = 3f; // Maksymalna odleg³oœæ interakcji
    private bool isDialogueActive = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // Obs³uga klawisza Escape
        if (Input.GetKeyDown(KeyCode.Escape) && isDialogueActive)
        {
            CloseDialogue(); // Zamknij dialog
        }

        // Sprawdzenie odleg³oœci gracza i obs³uga klawisza E
        if (distanceToPlayer <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Naciœniêcie klawisza E
            {
                if (isDialogueActive)
                {
                    CloseDialogue(); // Wy³¹cz dialog
                }
                else
                {
                    OpenDialogue(); // W³¹cz dialog
                }
            }
        }
        else if (isDialogueActive) // Jeœli gracz wyjdzie poza zasiêg
        {
            CloseDialogue(); // Zamknij dialog
        }
    }

    void OpenDialogue()
    {
        isDialogueActive = true;
        dialogueUI.SetActive(true);
        Time.timeScale = 0; // Pauzuj grê

        // Blokuj ruch i kamerê
        var controller = player.GetComponent<FirstPersonController>();
        controller.canMove = false; // Blokada ruchu
        controller.enableCameraRotation = false; // Blokada kamery

        // Poka¿ kursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
        Time.timeScale = 1; // Wznów grê

        // Odblokuj ruch i kamerê
        var controller = player.GetComponent<FirstPersonController>();
        controller.canMove = true; // Odblokuj ruch
        controller.enableCameraRotation = true; // Odblokuj kamerê

        // Ukryj kursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
