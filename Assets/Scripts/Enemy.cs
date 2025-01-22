using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Maksymalne zdrowie przeciwnika
    private int currentHealth; // Obecne zdrowie przeciwnika
    public BossSpawner bossSpawner;
    void Start()
    {
        currentHealth = maxHealth; // Inicjalizuj zdrowie na maksymalne
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Przeciwnik {gameObject.name} otrzyma� {damage} obra�e�. Pozosta�e HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"Przeciwnik {gameObject.name} zosta� zniszczony!");
        if (bossSpawner != null)
        {
            bossSpawner.EnemyDestroyed();
        }
        Destroy(gameObject);
    }
}
