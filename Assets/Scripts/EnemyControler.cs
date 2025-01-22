using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Prêdkoœæ ruchu statku przeciwnika
    public float rotationSpeed = 2f; // Prêdkoœæ obracania statku przeciwnika
    public float changeDirectionInterval = 3f; // Czas pomiêdzy zmianami kierunku

    [Header("Shooting Settings")]
    public GameObject laserPrefab; // Prefab lasera
    public Transform shootingPoint; // Punkt, z którego bêd¹ wystrzeliwane lasery
    public float shootingRange = 15f; // Zasiêg strza³ów
    public float shootingInterval = 2f; // Czas pomiêdzy kolejnymi strza³ami

    private Vector3 targetDirection; // Docelowy kierunek ruchu
    private float changeDirectionTimer; // Licznik do zmiany kierunku
    private Transform player; // Gracz
    private float shootingTimer; // Licznik do strza³ów

    void Start()
    {
        // Ustawienie pocz¹tkowego kierunku
        SetRandomDirection();
        changeDirectionTimer = changeDirectionInterval;

        // Szukamy obiektu gracza w scenie
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }

        shootingTimer = shootingInterval;
    }

    void Update()
    {
        // Jeœli gracz nie istnieje, nie kontynuuj
        if (player == null) return;

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

        // Sprawdzanie, czy gracz jest w zasiêgu
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= shootingRange)
        {
            // Aktualizujemy timer strzelania
            shootingTimer -= Time.deltaTime;

            // Strzelanie, gdy minie czas strza³u
            if (shootingTimer <= 0f)
            {
                ShootAtPlayer();
                shootingTimer = shootingInterval;
            }
        }
    }

    private void SetRandomDirection()
    {
        // Wygenerowanie losowego kierunku w trójwymiarowej przestrzeni
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        targetDirection = new Vector3(randomX, randomY, randomZ).normalized;
    }

    private void ShootAtPlayer()
    {
        // Wystrzeliwujemy laser w stronê gracza
        if (laserPrefab != null && shootingPoint != null)
        {
            GameObject laser = Instantiate(laserPrefab, shootingPoint.position, Quaternion.LookRotation(player.position - transform.position));
            Laser laserScript = laser.GetComponent<Laser>();
            if (laserScript != null)
            {
                laserScript.damage = 10; // Ustawiamy obra¿enia lasera
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Jeœli statek zderzy siê z czymœ, zmieñ kierunek na nowy losowy
        SetRandomDirection();
    }
}
