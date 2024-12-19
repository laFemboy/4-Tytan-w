using UnityEngine;

public class Npcinteraction : MonoBehaviour
{
    public GameObject dialogueUI; // UI dialogowe
    public GameObject player; // Obiekt gracza
    public float interactionDistance = 3f; // Maksymalna odleg³oœæ interakcji
    private bool isDialogueActive = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= interactionDistance) // Jeœli gracz jest w zasiêgu
        {
            if (Input.GetKeyDown(KeyCode.E)) // Naciœniêcie klawisza E
            {
                isDialogueActive = !isDialogueActive; // Prze³¹cz dialog
                dialogueUI.SetActive(isDialogueActive);
                Time.timeScale = isDialogueActive ? 0 : 1; // Pauzuj grê

                // Blokuj ruch i kamerê
                var controller = player.GetComponent<FirstPersonController>();
                controller.canMove = !isDialogueActive; // Blokada ruchu
                controller.enableCameraRotation = !isDialogueActive; // Blokada kamery (dodane pole w skrypcie FirstPersonController)

                // Poka¿/ukryj kursor
                Cursor.lockState = isDialogueActive ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = isDialogueActive;
            }
        }
        else if (isDialogueActive) // Jeœli gracz wyjdzie poza zasiêg
        {
            isDialogueActive = false;
            dialogueUI.SetActive(false); // Wy³¹cza UI dialogowe
            Time.timeScale = 1; // Wznawia grê

            // Odblokuj ruch i kamerê
            var controller = player.GetComponent<FirstPersonController>();
            controller.canMove = true;
            controller.enableCameraRotation = true;

            // Ukryj kursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
