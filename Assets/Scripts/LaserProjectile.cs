using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float speed = 20f;  // Pr�dko�� lasera
    public float lifeTime = 2f;  // Czas �ycia lasera
    private Rigidbody rb;

    void Start()
    {
        // Zniszcz laser po okre�lonym czasie
        Destroy(gameObject, lifeTime);

        // Pobierz komponent Rigidbody
        rb = GetComponent<Rigidbody>();

        // Ustaw pr�dko�� lasera
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * speed;  // Porusz laser w kierunku osi Z
        }
    }

    void Update()
    {
        // Mo�esz r�wnie� doda� dodatkow� logik�, ale fizyka powinna porusza� laserem
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy obiekt trafiony to statek przeciwnika
        EnemyShip enemy = other.GetComponent<EnemyShip>();
        if (enemy != null)
        {
            enemy.TakeDamage(10); // Zadaj 10 obra�e�
            Destroy(gameObject); // Usu� laser po trafieniu
        }
    }
}
