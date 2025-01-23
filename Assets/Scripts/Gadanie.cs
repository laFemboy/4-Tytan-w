using UnityEngine;

public class Gadanie : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Stop(); // Na pocz¹tku zatrzymujemy dŸwiêk
        }
    }

    private void Update()
    {
        // Sprawdzanie, czy klawisz E zosta³ naciœniêty
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (audioSource != null)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop(); // Zatrzymanie dŸwiêku, jeœli ju¿ gra
                }
                else
                {
                    audioSource.Play(); // Rozpoczêcie odtwarzania dŸwiêku, jeœli nie gra
                }
            }
        }
    }

    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // Zatrzymanie dŸwiêku
        }
    }
}
