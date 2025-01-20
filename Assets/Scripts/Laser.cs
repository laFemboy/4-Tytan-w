using UnityEngine;

public class Laser : MonoBehaviour
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
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Zadaj obra¿enia przeciwnikowi
            Destroy(gameObject); // Zniszcz laser po trafieniu
        }
    }
}
