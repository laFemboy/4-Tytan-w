using UnityEngine;
using System.Collections.Generic;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public float moveSpeed = 5f; // Prêdkoœæ ruchu bossa
    public float rotationSpeed = 5f; // Prêdkoœæ obracania siê bossa w stronê gracza
    public float stoppingDistance = 2f; // Minimalna odleg³oœæ od gracza, na której boss siê zatrzyma

    [Header("Shooting Settings")]
    public GameObject laserPrefab; // Prefab lasera
    public List<Transform> shootingPoints; // Lista punktów strza³u
    public float shootingRange = 20f; // Zasiêg strza³ów
    public float shootingInterval = 1.5f; // Czas pomiêdzy kolejnymi strza³ami

    private Transform player; // Referencja do transformacji gracza
    private float shootingTimer; // Licznik do strza³ów

    void Start()
    {
        // ZnajdŸ obiekt gracza po tagu "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("BossController: Nie znaleziono gracza z tagiem 'Player'.");
        }

        // Inicjalizacja timera strzelania
        shootingTimer = shootingInterval;

        // Sprawdzenie, czy lista punktów strza³u nie jest pusta
        if (shootingPoints == null || shootingPoints.Count == 0)
        {
            Debug.LogWarning("BossController: Lista punktów strza³u jest pusta!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Oblicz dystans do gracza
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Poruszaj siê w kierunku gracza, jeœli jest dalej ni¿ dystans zatrzymania
        if (distanceToPlayer > stoppingDistance)
        {
            MoveTowardsPlayer();
        }

        // SprawdŸ, czy gracz jest w zasiêgu strza³u
        if (distanceToPlayer <= shootingRange)
        {
            // Aktualizujemy timer strzelania
            shootingTimer -= Time.deltaTime;

            // Strzelaj, jeœli up³yn¹³ czas strza³u
            if (shootingTimer <= 0f)
            {
                ShootAtPlayer();
                shootingTimer = shootingInterval;
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // Kierunek do gracza
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Obracanie siê w stronê gracza
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Poruszanie siê w stronê gracza
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void ShootAtPlayer()
    {
        // Wystrzeliwujemy lasery ze wszystkich punktów strza³u
        if (laserPrefab != null && shootingPoints != null && shootingPoints.Count > 0)
        {
            foreach (Transform shootingPoint in shootingPoints)
            {
                if (shootingPoint != null)
                {
                    GameObject laser = Instantiate(laserPrefab, shootingPoint.position, Quaternion.LookRotation(player.position - shootingPoint.position));
                    Laser laserScript = laser.GetComponent<Laser>();
                    if (laserScript != null)
                    {
                        laserScript.damage = 20; // Ustaw obra¿enia lasera
                    }
                }
            }

            Debug.Log("Boss strzeli³ laserami ze wszystkich punktów.");
        }
        else
        {
            Debug.LogWarning("BossController: Brak przypisanego prefab lasera lub lista punktów strza³u jest pusta.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Rysowanie wizualizacji odleg³oœci zatrzymania i zasiêgu strza³u
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        // Rysowanie punktów strza³u
        if (shootingPoints != null)
        {
            Gizmos.color = Color.green;
            foreach (Transform shootingPoint in shootingPoints)
            {
                if (shootingPoint != null)
                {
                    Gizmos.DrawSphere(shootingPoint.position, 0.2f);
                }
            }
        }
    }
}
