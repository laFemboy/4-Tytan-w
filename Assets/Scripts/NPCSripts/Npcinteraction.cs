using UnityEngine;

public class Npcinteraction : MonoBehaviour
{
    public GameObject dialogueUI; // UI dialogowe
    public GameObject player; // Obiekt gracza
    public float interactionDistance = 3f; // Maksymalna odleg�o�� interakcji
    private bool isDialogueActive = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= interactionDistance) // Je�li gracz jest w zasi�gu
        {
            if (Input.GetKeyDown(KeyCode.E)) // Naci�ni�cie klawisza E
            {
                isDialogueActive = !isDialogueActive; // Prze��cz dialog
                dialogueUI.SetActive(isDialogueActive);
                Time.timeScale = isDialogueActive ? 0 : 1; // Pauzuj gr�

                // Blokuj ruch i kamer�
                var controller = player.GetComponent<FirstPersonController>();
                controller.canMove = !isDialogueActive; // Blokada ruchu
                controller.enableCameraRotation = !isDialogueActive; // Blokada kamery (dodane pole w skrypcie FirstPersonController)

                // Poka�/ukryj kursor
                Cursor.lockState = isDialogueActive ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = isDialogueActive;
            }
        }
        else if (isDialogueActive) // Je�li gracz wyjdzie poza zasi�g
        {
            isDialogueActive = false;
            dialogueUI.SetActive(false); // Wy��cza UI dialogowe
            Time.timeScale = 1; // Wznawia gr�

            // Odblokuj ruch i kamer�
            var controller = player.GetComponent<FirstPersonController>();
            controller.canMove = true;
            controller.enableCameraRotation = true;

            // Ukryj kursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
