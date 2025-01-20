using UnityEngine;

public class Laser : MonoBehaviour
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
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Zadaj obra�enia przeciwnikowi
            Destroy(gameObject); // Zniszcz laser po trafieniu
        }
    }
}
