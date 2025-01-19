using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int maxHP = 100;  // Maksymalne punkty ¿ycia
    private int currentHP;  // Aktualne punkty ¿ycia

    void Start()
    {
        // Ustaw pocz¹tkowe punkty ¿ycia
        currentHP = maxHP;
    }

    // Funkcja przyjmuj¹ca obra¿enia
    public void TakeDamage(int damage)
    {
        currentHP -= damage; // Zmniejsz HP o wartoœæ obra¿eñ
        Debug.Log(gameObject.name + " otrzyma³ obra¿enia: " + damage);

        // SprawdŸ, czy HP spad³o do zera lub poni¿ej
        if (currentHP <= 0)
        {
            Die(); // Zniszczenie statku
        }
    }

    // Funkcja niszczenia statku
    private void Die()
    {
        Debug.Log(gameObject.name + " zosta³ zniszczony!");
        Destroy(gameObject); // Usuñ obiekt z gry
    }
}
