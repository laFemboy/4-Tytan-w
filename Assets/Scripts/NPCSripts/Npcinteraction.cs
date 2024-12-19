using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject dialogueUI; // UI dialogowe
    public GameObject player;
    public float interactionDistance = 3f; // Maksymalna odleg�o�� interakcji
    private bool isDialogueActive = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // Obs�uga klawisza Escape
        if (Input.GetKeyDown(KeyCode.Escape) && isDialogueActive)
        {
            CloseDialogue(); // Zamknij dialog
        }

        // Sprawdzenie odleg�o�ci gracza i obs�uga klawisza E
        if (distanceToPlayer <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Naci�ni�cie klawisza E
            {
                if (isDialogueActive)
                {
                    CloseDialogue(); // Wy��cz dialog
                }
                else
                {
                    OpenDialogue(); // W��cz dialog
                }
            }
        }
        else if (isDialogueActive) // Je�li gracz wyjdzie poza zasi�g
        {
            CloseDialogue(); // Zamknij dialog
        }
    }

    void OpenDialogue()
    {
        isDialogueActive = true;
        dialogueUI.SetActive(true);
        Time.timeScale = 0; // Pauzuj gr�

        // Blokuj ruch i kamer�
        var controller = player.GetComponent<FirstPersonController>();
        controller.canMove = false; // Blokada ruchu
        controller.enableCameraRotation = false; // Blokada kamery

        // Poka� kursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
        Time.timeScale = 1; // Wzn�w gr�

        // Odblokuj ruch i kamer�
        var controller = player.GetComponent<FirstPersonController>();
        controller.canMove = true; // Odblokuj ruch
        controller.enableCameraRotation = true; // Odblokuj kamer�

        // Ukryj kursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
