using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Panel z menu pauzy
    public Button resumeButton;     // Przycisk Wznów
    public Button hangarButton;     // Przycisk Wróæ do Hangaru
    public Button mainMenuButton;   // Przycisk Menu G³ówne
    public Button quitButton;       // Przycisk WyjdŸ z gry

    private bool isPaused = false;

    void Start()
    {
        // Dodaj nas³uchiwacze przycisków
        resumeButton.onClick.AddListener(ResumeGame);
        hangarButton.onClick.AddListener(ReturnToHangar);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        quitButton.onClick.AddListener(QuitGame);

        pauseMenuUI.SetActive(false); // Menu pauzy pocz¹tkowo jest ukryte
    }

    void Update()
    {
        // Naciœniêcie ESC powoduje pauzê
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
        Time.timeScale = 0f; // Zatrzymanie gry, ale UI i input dzia³aj¹ normalnie
        pauseMenuUI.SetActive(true); // Wyœwietlenie menu pauzy

        // Zmiana kursora, aby by³ widoczny i nie by³ zablokowany
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Funkcja wznowienia gry
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Wznowienie gry
        pauseMenuUI.SetActive(false); // Ukrycie menu pauzy

        // Zablokowanie kursora, aby nie móg³ byæ u¿ywany w trakcie gry
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Powrót do Hangaru
    void ReturnToHangar()
    {
        // Zapisz postêp lub ustawienia w Hangarze
        // Mo¿esz tu dodaæ logikê zapisu stanu gry

        Time.timeScale = 1f; // Wznowienie gry
        SceneManager.LoadScene("Hangar"); // Za³adowanie sceny Hangar
    }

    // Powrót do Menu G³ównego
    void ReturnToMainMenu()
    {
        // Zapisz postêp lub ustawienia w Menu G³ównym
        // Mo¿esz tu dodaæ logikê zapisu stanu gry

        Time.timeScale = 1f; // Wznowienie gry
        SceneManager.LoadScene("Menu G³ówne"); // Za³adowanie sceny Menu G³ówne
    }

    // Wyjœcie z gry
    void QuitGame()
    {
        Application.Quit(); // Zamyka aplikacjê
    }
}
