using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject panel;
    public GameObject Audiopanel;// Panel Opcje
    public Button przyciskOpcje; // Przycisk Opcje
    public Slider musicSlider; // Suwak do muzyki
    public Slider shotsSlider; // Suwak do strza��w
    public Slider engineSlider; // Suwak do silnika
    public Slider voiceSlider; // Suwak do gadania

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource shotsSource;
    public AudioSource engineSource;
    public AudioSource voiceSource;

    private string previousScene; // Nazwa poprzedniej sceny



    void Start()
    {
        // Ukryj panel na starcie
        panel.SetActive(false);

        // Za�aduj zapisane warto�ci g�o�no�ci
        LoadVolumeSettings();

        // Dodaj nas�uch na zmiany warto�ci suwak�w
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        shotsSlider.onValueChanged.AddListener(OnShotsVolumeChange);
        engineSlider.onValueChanged.AddListener(OnEngineVolumeChange);
        voiceSlider.onValueChanged.AddListener(OnVoiceVolumeChange);
    }

    private void LoadVolumeSettings()
    {
        if (musicSource) musicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        if (shotsSource) shotsSource.volume = PlayerPrefs.GetFloat("ShotsVolume", 1.0f);
        if (engineSource) engineSource.volume = PlayerPrefs.GetFloat("EngineVolume", 1.0f);
        if (voiceSource) voiceSource.volume = PlayerPrefs.GetFloat("VoiceVolume", 1.0f);

        // Ustaw suwaki na za�adowane warto�ci
        if (musicSlider) musicSlider.value = musicSource.volume;
        if (shotsSlider) shotsSlider.value = shotsSource.volume;
        if (engineSlider) engineSlider.value = engineSource.volume;
        if (voiceSlider) voiceSlider.value = voiceSource.volume;
    }

    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSource ? musicSource.volume : 1.0f);
        PlayerPrefs.SetFloat("ShotsVolume", shotsSource ? shotsSource.volume : 1.0f);
        PlayerPrefs.SetFloat("EngineVolume", engineSource ? engineSource.volume : 1.0f);
        PlayerPrefs.SetFloat("VoiceVolume", voiceSource ? voiceSource.volume : 1.0f);

        PlayerPrefs.Save(); // Zapisz zmiany
    }

    public void Opcje() {

        Audiopanel.SetActive(true);


    }
    public void Wroc()
    {
        SaveVolumeSettings(); // Zapisz ustawienia przed zamkni�ciem panelu
        panel.SetActive(false);
        Audiopanel.SetActive(false);
        // Ponownie poka� przycisk Opcje
        if (przyciskOpcje != null)
        {
            przyciskOpcje.gameObject.SetActive(true);
        }
    }

    public void Sterowanie()
    {
        panel.SetActive(true);

        // Ukryj przycisk Opcje
        if (przyciskOpcje != null)
        {
            przyciskOpcje.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        SaveVolumeSettings(); // Zapisz ustawienia przed zmian� sceny
        SceneManager.LoadScene("Hangar");
    }

    public void WrocDoPoprzedniegoPanelu()
    {
        SaveVolumeSettings(); // Zapisz ustawienia przed powrotem do poprzedniego panelu
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene); // Za�aduj poprzedni� scen�
        }
    }

    // Metody obs�uguj�ce zmiany g�o�no�ci
    public void OnMusicVolumeChange(float value)
    {
        if (musicSource) musicSource.volume = value;
    }

    public void OnShotsVolumeChange(float value)
    {
        if (shotsSource) shotsSource.volume = value;
    }

    public void OnEngineVolumeChange(float value)
    {
        if (engineSource) engineSource.volume = value;
    }

    public void OnVoiceVolumeChange(float value)
    {
        if (voiceSource) voiceSource.volume = value;
    }
}
