using UnityEngine;

public class DialogGeneral : MonoBehaviour
{
    public GameObject Powitanie;
    public GameObject Powrot;
    public GameObject Cozrobic;
    public GameObject AlePaskudny;
    public GameObject SpecjalneZlecenia;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CloseAllDialogs();
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
