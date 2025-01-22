using UnityEngine;

public class DialogGeneral : MonoBehaviour
{
    public GameObject Powitanie;
    public GameObject Powrot;
    public GameObject Cozrobic;
    public GameObject AlePaskudny;
    public GameObject SpecjalneZlecenia;
    public GameObject player; // Obiekt gracza
    public float interactionDistance = 3f; // Maksymalna odleg�o�� interakcji
    private bool isDialogueActive = false;

    void Update()
    {
        // Oblicz dystans mi�dzy graczem a NPC
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // Sprawd�, czy gracz jest w zasi�gu
        if (distanceToPlayer <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isDialogueActive)
                {
                    CloseAllDialogs();
                    isDialogueActive = false; // Wy��cz tryb dialogu
                }
                else
                {
                    Powitanie.SetActive(true);
                    isDialogueActive = true; // W��cz tryb dialogu
                }
            }
        }
        else if (isDialogueActive) // Je�li gracz wyjdzie poza zasi�g
        {
            CloseAllDialogs();
            isDialogueActive = false;
        }
    }

    public void OpenCozrobic()
    {
        CloseAllDialogs();
        Cozrobic.SetActive(true);
    }

    public void OpenAlepaskudny()
    {
        CloseAllDialogs();
        AlePaskudny.SetActive(true);
    }

    public void OpenSpecjalneZlecenia()
    {
        CloseAllDialogs();
        SpecjalneZlecenia.SetActive(true);
    }

    public void DoPowrot()
    {
        CloseAllDialogs();
        Powrot.SetActive(true);
    }

    private void CloseAllDialogs()
    {
        Powitanie.SetActive(false);
        Powrot.SetActive(false);
        Cozrobic.SetActive(false);
        AlePaskudny.SetActive(false);
        SpecjalneZlecenia.SetActive(false);
    }
}
