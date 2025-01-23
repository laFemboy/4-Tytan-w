using UnityEngine;

public class AsteroidHP : MonoBehaviour
{
    [Header("Asteroid Health Settings")]
    public int maxHealth = 50; // Maksymalne zdrowie asteroidy
    private int currentHealth; // Aktualne zdrowie asteroidy

    [Header("Player Interaction")]
    public int healthReward = 10; // Ilo�� zdrowia, kt�re gracz odzyskuje po zniszczeniu asteroidy


    void Start()
    {
        // Inicjalizacja zdrowia asteroidy
        currentHealth = maxHealth;
    }

    // Funkcja do zadawania obra�e� asteroidzie
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Asteroida otrzyma�a {damage} obra�e�. Aktualne zdrowie: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            DestroyAsteroid(); // Zniszcz asteroid�, gdy zdrowie wynosi 0
        }
    }

    private void DestroyAsteroid()
    {
        Debug.Log("Asteroida zosta�a zniszczona!");


        // Znajd� gracza i przyznaj mu zdrowie
        PlayerHealth player = FindPlayerHealth();
        if (player != null)
        {
            player.currentHealth += healthReward;
            player.currentHealth = Mathf.Clamp(player.currentHealth, 0, player.maxHealth);
            Debug.Log($"Gracz odzyska� {healthReward} zdrowia. Aktualne zdrowie gracza: {player.currentHealth}/{player.maxHealth}");
        }

        // Zniszcz obiekt asteroidy
        Destroy(gameObject);
    }

    private PlayerHealth FindPlayerHealth()
    {
        // U�yj nowej metody do znajdowania obiektu
        return Object.FindFirstObjectByType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy laser gracza trafi� asteroid�
        Laser laser = other.GetComponent<Laser>();
        if (laser != null)
        {
            TakeDamage(laser.damage); // Zadawanie obra�e� asteroidzie
            Destroy(other.gameObject); // Zniszcz laser po trafieniu
        }
    }
}
