using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksymalne zdrowie gracza
    public int currentHealth; // Aktualne zdrowie gracza

    void Start()
    {
        currentHealth = maxHealth; // Inicjalizacja zdrowia
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ograniczenie zdrowia w przedziale od 0 do maxHealth
        Debug.Log($"Gracz otrzyma� {damage} obra�e�. Zdrowie: {currentHealth}/{maxHealth}");

        if (currentHealth == 0) // Sprawd�, czy gracz nie ma ju� zdrowia
        {
            DestroyObject(); // Wywo�anie metody niszcz�cej gracza
        }
    }

    private void DestroyObject()
    {
        Debug.Log("Gracz zosta� zniszczony.");
        Destroy(gameObject); // Usuni�cie obiektu gracza z gry
    }
}
