using UnityEngine;

public class BossHP : MonoBehaviour
{
    [Header("Boss Health Settings")]
    public int maxHealth = 100; // Maksymalne zdrowie bossa
    private int currentHealth; // Aktualne zdrowie bossa

    [Header("Visual Effects")]
    public GameObject deathEffect; // Efekt wybuchu bossa po �mierci

    void Start()
    {
        // Inicjalizacja zdrowia
        currentHealth = maxHealth;
    }

    // Funkcja do zadawania obra�e� bossowi
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Odejmij obra�enia od aktualnego zdrowia
        Debug.Log($"Boss otrzyma� {damage} obra�e�. Aktualne zdrowie: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Wywo�aj �mier� bossa
        }
    }

    private void Die()
    {
        Debug.Log("Boss zosta� pokonany!");

        // Wyzwolenie efektu �mierci, je�li jest przypisany
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        // Mo�esz tu doda� inne efekty, jak np. zdobycie punkt�w przez gracza
        Destroy(gameObject); // Zniszczenie obiektu bossa
    }

    private void OnTriggerEnter(Collider other)
    {
        Laser laser = other.GetComponent<Laser>();
        if (laser != null)
        {
            TakeDamage(laser.damage); // Boss otrzymuje obra�enia od lasera
            Destroy(other.gameObject); // Zniszcz laser po trafieniu
        }
    }
}
