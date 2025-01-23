using UnityEngine;

public class AsteroidHP : MonoBehaviour
{
    [Header("Asteroid Health Settings")]
    public int maxHealth = 50; // Maksymalne zdrowie asteroidy
    private int currentHealth; // Aktualne zdrowie asteroidy

    [Header("Player Interaction")]
    public int healthReward = 10; // Iloœæ zdrowia, które gracz odzyskuje po zniszczeniu asteroidy


    void Start()
    {
        // Inicjalizacja zdrowia asteroidy
        currentHealth = maxHealth;
    }

    // Funkcja do zadawania obra¿eñ asteroidzie
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Asteroida otrzyma³a {damage} obra¿eñ. Aktualne zdrowie: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            DestroyAsteroid(); // Zniszcz asteroidê, gdy zdrowie wynosi 0
        }
    }

    private void DestroyAsteroid()
    {
        Debug.Log("Asteroida zosta³a zniszczona!");


        // ZnajdŸ gracza i przyznaj mu zdrowie
        PlayerHealth player = FindPlayerHealth();
        if (player != null)
        {
            player.currentHealth += healthReward;
            player.currentHealth = Mathf.Clamp(player.currentHealth, 0, player.maxHealth);
            Debug.Log($"Gracz odzyska³ {healthReward} zdrowia. Aktualne zdrowie gracza: {player.currentHealth}/{player.maxHealth}");
        }

        // Zniszcz obiekt asteroidy
        Destroy(gameObject);
    }

    private PlayerHealth FindPlayerHealth()
    {
        // U¿yj nowej metody do znajdowania obiektu
        return Object.FindFirstObjectByType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy laser gracza trafi³ asteroidê
        Laser laser = other.GetComponent<Laser>();
        if (laser != null)
        {
            TakeDamage(laser.damage); // Zadawanie obra¿eñ asteroidzie
            Destroy(other.gameObject); // Zniszcz laser po trafieniu
        }
    }
}
