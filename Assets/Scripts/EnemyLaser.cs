using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 20f; // Prêdkoœæ lasera
    public float lifetime = 2f; // Czas ¿ycia lasera
    public int damage = 10; // Iloœæ zadawanych obra¿eñ

    void Start()
    {
        Destroy(gameObject, lifetime); // Automatyczne usuniêcie lasera po okreœlonym czasie
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy obiekt ma tag "Player"
        if (other.CompareTag("Player"))
        {
            // ZnajdŸ komponent gracza, który mo¿e przyj¹æ obra¿enia
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Zadaj obra¿enia graczowi
                Debug.Log("Gracz zosta³ trafiony przez laser wroga! Zada³em " + damage + " obra¿eñ.");
            }
        }

        // Zniszcz laser po kontakcie
        Destroy(gameObject);
    }
}
