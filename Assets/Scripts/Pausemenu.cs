using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Panel z menu pauzy
    public Button resumeButton;     // Przycisk Wzn�w
    public Button hangarButton;     // Przycisk Wr�� do Hangaru
    public Button mainMenuButton;   // Przycisk Menu G��wne
    public Button quitButton;       // Przycisk Wyjd� z gry

    private bool isPaused = false;

    void Start()
    {
        // Dodaj nas�uchiwacze przycisk�w
        resumeButton.onClick.AddListener(ResumeGame);
        hangarButton.onClick.AddListener(ReturnToHangar);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        quitButton.onClick.AddListener(QuitGame);

        pauseMenuUI.SetActive(false); // Menu pauzy pocz�tkowo jest ukryte
    }

    void Update()
    {
        // Naci�ni�cie ESC powoduje pauz�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Funkcja pauzy
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Zatrzymanie gry, ale UI i input dzia�aj� normalnie
        pauseMenuUI.SetActive(true); // Wy�wietlenie menu pauzy

        // Zmiana kursora, aby by� widoczny i nie by� zablokowany
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Funkcja wznowienia gry
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Wznowienie gry
        pauseMenuUI.SetActive(false); // Ukrycie menu pauzy

        // Zablokowanie kursora, aby nie m�g� by� u�ywany w trakcie gry
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Powr�t do Hangaru
    void ReturnToHangar()
    {
        // Zapisz post�p lub ustawienia w Hangarze
        // Mo�esz tu doda� logik� zapisu stanu gry

        Time.timeScale = 1f; // Wznowienie gry
        SceneManager.LoadScene("Hangar"); // Za�adowanie sceny Hangar
    }

    // Powr�t do Menu G��wnego
    void ReturnToMainMenu()
    {
        // Zapisz post�p lub ustawienia w Menu G��wnym
        // Mo�esz tu doda� logik� zapisu stanu gry

        Time.timeScale = 1f; // Wznowienie gry
        SceneManager.LoadScene("Menu G��wne"); // Za�adowanie sceny Menu G��wne
    }

    // Wyj�cie z gry
    void QuitGame()
    {
        Application.Quit(); // Zamyka aplikacj�
    }
}
