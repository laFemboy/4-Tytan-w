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
        Debug.Log($"Gracz otrzyma³ {damage} obra¿eñ. Zdrowie: {currentHealth}/{maxHealth}");

        if (currentHealth == 0) // SprawdŸ, czy gracz nie ma ju¿ zdrowia
        {
            DestroyObject(); // Wywo³anie metody niszcz¹cej gracza
        }
    }

    private void DestroyObject()
    {
        Debug.Log("Gracz zosta³ zniszczony.");
        Destroy(gameObject); // Usuniêcie obiektu gracza z gry
    }
}
