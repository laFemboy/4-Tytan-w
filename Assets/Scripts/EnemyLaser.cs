using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 20f; // Pr�dko�� lasera
    public float lifetime = 2f; // Czas �ycia lasera

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
            // Mo�esz doda� kod reaguj�cy na trafienie gracza, np. wy�wietlanie efektu trafienia lub inne dzia�anie
            Debug.Log("Gracz zosta� trafiony przez laser wroga!");

            // Mo�esz tu doda� dodatkow� logik�, np. zadawanie obra�e� graczowi, je�li chcesz
            // Gracz nie otrzymuje obra�e� w tym przyk�adzie, ale mo�esz doda� odpowiedni skrypt w tym miejscu
        }

        // Zniszcz laser po kontakcie
        Destroy(gameObject);
    }
}
