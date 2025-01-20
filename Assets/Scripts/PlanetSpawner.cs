using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public List<GameObject> planetPrefabs; // Lista prefabów planet
    public int numberOfPlanets; // Liczba planet do stworzenia
    public Vector3 spawnArea = new Vector3(100, 100, 100); // Obszar spawnowania

    void Start()
    {
        SpawnPlanets();
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Wybierz losowy prefab z listy
            GameObject randomPlanetPrefab = planetPrefabs[Random.Range(0, planetPrefabs.Count)];

            // Stwórz now¹ planetê
            Instantiate(randomPlanetPrefab, randomPosition, Quaternion.identity);
        }
    }
}
