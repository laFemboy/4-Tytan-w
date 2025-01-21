using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Pocz¹tkowe zdrowie gracza

    // Metoda do przyjmowania obra¿eñ
    public void TakeDamage(int damage)
    {
        health -= damage; // Zmniejsz zdrowie gracza
        Debug.Log($"Przeciwnik  otrzyma³ {damage} obra¿eñ. Pozosta³e HP:");
        if (health <= 0)
        {
            Die(); // Jeœli zdrowie gracza spadnie do 0, gracz umiera
        }
    }

    // Metoda umierania gracza (mo¿esz rozbudowaæ j¹ o animacjê, dŸwiêk, itp.)
    private void Die()
    {
        Debug.Log("Gracz umiera!");
        // Mo¿esz dodaæ logikê umierania, np. reset poziomu, animacjê umierania itp.
        Destroy(gameObject); // Zniszczenie obiektu gracza
    }
}
