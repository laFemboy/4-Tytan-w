using UnityEngine;
using System.Collections.Generic;

public class BossController : MonoBehaviour
{
    [Header("Boss Settings")]
    public float moveSpeed = 5f; // Pr�dko�� ruchu bossa
    public float rotationSpeed = 5f; // Pr�dko�� obracania si� bossa w stron� gracza
    public float stoppingDistance = 2f; // Minimalna odleg�o�� od gracza, na kt�rej boss si� zatrzyma

    [Header("Shooting Settings")]
    public GameObject laserPrefab; // Prefab lasera
    public List<Transform> shootingPoints; // Lista punkt�w strza�u
    public float shootingRange = 20f; // Zasi�g strza��w
    public float shootingInterval = 1.5f; // Czas pomi�dzy kolejnymi strza�ami

    private Transform player; // Referencja do transformacji gracza
    private float shootingTimer; // Licznik do strza��w

    void Start()
    {
        // Znajd� obiekt gracza po tagu "Player"
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

        // Sprawdzenie, czy lista punkt�w strza�u nie jest pusta
        if (shootingPoints == null || shootingPoints.Count == 0)
        {
            Debug.LogWarning("BossController: Lista punkt�w strza�u jest pusta!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Oblicz dystans do gracza
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Poruszaj si� w kierunku gracza, je�li jest dalej ni� dystans zatrzymania
        if (distanceToPlayer > stoppingDistance)
        {
            MoveTowardsPlayer();
        }

        // Sprawd�, czy gracz jest w zasi�gu strza�u
        if (distanceToPlayer <= shootingRange)
        {
            // Aktualizujemy timer strzelania
            shootingTimer -= Time.deltaTime;

            // Strzelaj, je�li up�yn�� czas strza�u
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

        // Obracanie si� w stron� gracza
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Poruszanie si� w stron� gracza
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void ShootAtPlayer()
    {
        // Wystrzeliwujemy lasery ze wszystkich punkt�w strza�u
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
                        laserScript.damage = 20; // Ustaw obra�enia lasera
                    }
                }
            }

            Debug.Log("Boss strzeli� laserami ze wszystkich punkt�w.");
        }
        else
        {
            Debug.LogWarning("BossController: Brak przypisanego prefab lasera lub lista punkt�w strza�u jest pusta.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Rysowanie wizualizacji odleg�o�ci zatrzymania i zasi�gu strza�u
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRange);

        // Rysowanie punkt�w strza�u
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
