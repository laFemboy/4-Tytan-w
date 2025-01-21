using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 20f; // Prêdkoœæ lasera
    public float lifetime = 2f; // Czas ¿ycia lasera

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
            // Mo¿esz dodaæ kod reaguj¹cy na trafienie gracza, np. wyœwietlanie efektu trafienia lub inne dzia³anie
            Debug.Log("Gracz zosta³ trafiony przez laser wroga!");

            // Mo¿esz tu dodaæ dodatkow¹ logikê, np. zadawanie obra¿eñ graczowi, jeœli chcesz
            // Gracz nie otrzymuje obra¿eñ w tym przyk³adzie, ale mo¿esz dodaæ odpowiedni skrypt w tym miejscu
        }

        // Zniszcz laser po kontakcie
        Destroy(gameObject);
    }
}
