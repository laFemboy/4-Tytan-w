using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Pocz�tkowe zdrowie gracza

    // Metoda do przyjmowania obra�e�
    public void TakeDamage(int damage)
    {
        health -= damage; // Zmniejsz zdrowie gracza
        Debug.Log($"Przeciwnik  otrzyma� {damage} obra�e�. Pozosta�e HP:");
        if (health <= 0)
        {
            Die(); // Je�li zdrowie gracza spadnie do 0, gracz umiera
        }
    }

    // Metoda umierania gracza (mo�esz rozbudowa� j� o animacj�, d�wi�k, itp.)
    private void Die()
    {
        Debug.Log("Gracz umiera!");
        // Mo�esz doda� logik� umierania, np. reset poziomu, animacj� umierania itp.
        Destroy(gameObject); // Zniszczenie obiektu gracza
    }
}
