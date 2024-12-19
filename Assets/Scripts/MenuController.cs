using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelOGrze;
    public GameObject panelWyjscieZGry;

    void Start()
    {
        if (SprawdzeniePaneliCzyNieNull())
            return;

        TogglePanels();
    }

    void Update()
    {
        IfEscPressed();
    }

    public void Wroc()
    {
        panelOGrze.SetActive(false);
        panelWyjscieZGry.SetActive(false);
    }

    public void OGrze()
    {
        panelOGrze.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Hangar");
    }

    private bool SprawdzeniePaneliCzyNieNull(){
        if (panelOGrze == null || panelWyjscieZGry == null)
        {
            Debug.LogError("Jedno z wymaganych pól nie jest przypisane.");
            return true;
        }
        return false;
    }

    public void WyjscieZGry()
    {
        Application.Quit();
    }

    private void TogglePanels()
    {
        panelOGrze.SetActive(false);
        panelWyjscieZGry.SetActive(false);
    }

    private void IfEscPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelOGrze.activeSelf)
            {
                Wroc();
                return;
            }
            
            if(panelWyjscieZGry.activeSelf)
                panelWyjscieZGry.SetActive(false);
            else
                panelWyjscieZGry.SetActive(true);
        }
    }
}
