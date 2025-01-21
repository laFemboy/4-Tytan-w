using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Prêdkoœæ ruchu statku przeciwnika
    public float rotationSpeed = 2f; // Prêdkoœæ obracania statku przeciwnika
    public float changeDirectionInterval = 3f; // Czas pomiêdzy zmianami kierunku

    private Vector3 targetDirection; // Docelowy kierunek ruchu
    private float changeDirectionTimer; // Licznik do zmiany kierunku

    void Start()
    {
        // Ustawienie pocz¹tkowego kierunku
        SetRandomDirection();
        changeDirectionTimer = changeDirectionInterval;
    }

    void Update()
    {
        // Aktualizacja licznika czasu do zmiany kierunku
        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0f)
        {
            // Ustaw nowy losowy kierunek
            SetRandomDirection();
            changeDirectionTimer = changeDirectionInterval;
        }

        // Obracanie statku w kierunku celu
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Poruszanie statku do przodu
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void SetRandomDirection()
    {
        // Wygenerowanie losowego kierunku w trójwymiarowej przestrzeni
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        targetDirection = new Vector3(randomX, randomY, randomZ).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Jeœli statek zderzy siê z czymœ, zmieñ kierunek na nowy losowy
        SetRandomDirection();
    }
}
