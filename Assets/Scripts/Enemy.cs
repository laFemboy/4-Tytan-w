using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Przeciwnik otrzyma³ {damage} obra¿eñ. Pozosta³e HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Przeciwnik zosta³ zniszczony!");
        Destroy(gameObject); // Usuñ przeciwnika
    }
}
