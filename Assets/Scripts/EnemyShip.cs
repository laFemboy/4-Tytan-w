using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int maxHP = 100;  // Maksymalne punkty �ycia
    private int currentHP;  // Aktualne punkty �ycia

    void Start()
    {
        // Ustaw pocz�tkowe punkty �ycia
        currentHP = maxHP;
    }

    // Funkcja przyjmuj�ca obra�enia
    public void TakeDamage(int damage)
    {
        currentHP -= damage; // Zmniejsz HP o warto�� obra�e�
        Debug.Log(gameObject.name + " otrzyma� obra�enia: " + damage);

        // Sprawd�, czy HP spad�o do zera lub poni�ej
        if (currentHP <= 0)
        {
            Die(); // Zniszczenie statku
        }
    }

    // Funkcja niszczenia statku
    private void Die()
    {
        Debug.Log(gameObject.name + " zosta� zniszczony!");
        Destroy(gameObject); // Usu� obiekt z gry
    }
}
