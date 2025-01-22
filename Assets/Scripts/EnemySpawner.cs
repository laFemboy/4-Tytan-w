using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public List<GameObject> enemyPrefabs; // Lista prefabów przeciwników
    public int minGroupSize = 2; // Minimalna liczba przeciwników w grupie
    public int maxGroupSize = 5; // Maksymalna liczba przeciwników w grupie
    public float spawnRadius = 50f; // Promieñ wokó³ spawnera, w którym mog¹ pojawiaæ siê grupy
    public float spawnInterval = 5f; // Czas miêdzy kolejnymi spawniami

    [Header("Map Boundaries")]
    public Vector3 mapCenter = Vector3.zero; // Œrodek mapy
    public Vector3 mapSize = new Vector3(100f, 100f, 100f); // Rozmiar mapy

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemyGroup();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemyGroup()
    {
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogWarning("EnemySpawner: No enemy prefabs assigned.");
            return;
        }

        // Okreœlenie liczby przeciwników w grupie
        int groupSize = Random.Range(minGroupSize, maxGroupSize + 1);

        // Losowa pozycja dla grupy w obrêbie mapy
        Vector3 groupCenter = new Vector3(
            Random.Range(mapCenter.x - mapSize.x / 2, mapCenter.x + mapSize.x / 2),
            Random.Range(mapCenter.y - mapSize.y / 2, mapCenter.y + mapSize.y / 2),
            Random.Range(mapCenter.z - mapSize.z / 2, mapCenter.z + mapSize.z / 2)
        );

        // Spawn przeciwników w grupie
        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnPosition = groupCenter + Random.insideUnitSphere * spawnRadius;
            spawnPosition = new Vector3(spawnPosition.x, Mathf.Clamp(spawnPosition.y, mapCenter.y - mapSize.y / 2, mapCenter.y + mapSize.y / 2), spawnPosition.z);

            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(mapCenter, mapSize);
    }
}
