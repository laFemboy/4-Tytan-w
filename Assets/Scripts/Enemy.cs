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
        Debug.Log($"Przeciwnik otrzyma� {damage} obra�e�. Pozosta�e HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Przeciwnik zosta� zniszczony!");
        Destroy(gameObject); // Usu� przeciwnika
    }
}
