using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 20f; // Pr�dko�� lasera
    public float lifetime = 2f; // Czas �ycia lasera
    public int damage = 10; // Ilo�� zadawanych obra�e�

    void Start()
    {
        Destroy(gameObject, lifetime); // Automatyczne usuni�cie lasera po okre�lonym czasie
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy obiekt ma tag "Player"
        if (other.CompareTag("Player"))
        {
            // Znajd� komponent gracza, kt�ry mo�e przyj�� obra�enia
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Zadaj obra�enia graczowi
                Debug.Log("Gracz zosta� trafiony przez laser wroga! Zada�em " + damage + " obra�e�.");
            }
        }

        // Zniszcz laser po kontakcie
        Destroy(gameObject);
    }
}
