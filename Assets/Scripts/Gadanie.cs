using UnityEngine;

public class Gadanie : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Stop(); // Na pocz�tku zatrzymujemy d�wi�k
        }
    }

    private void Update()
    {
        // Sprawdzanie, czy klawisz E zosta� naci�ni�ty
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (audioSource != null)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop(); // Zatrzymanie d�wi�ku, je�li ju� gra
                }
                else
                {
                    audioSource.Play(); // Rozpocz�cie odtwarzania d�wi�ku, je�li nie gra
                }
            }
        }
    }

    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // Zatrzymanie d�wi�ku
        }
    }
}
