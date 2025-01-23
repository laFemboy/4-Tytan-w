using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("Health Text")]
    public TextMeshProUGUI healthText; // Referencja do tekstu wyœwietlaj¹cego zdrowie

    [Header("Player Health")]
    public PlayerHealth playerHealth; // Referencja do skryptu zdrowia gracza

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            // Aktualizacja tekstu zdrowia
            healthText.text = $"{playerHealth.currentHealth}/{playerHealth.maxHealth}";
        }
    }
}
