using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab; // Prefab planety do instancjowania
    public int numberOfPlanets = 5; // Liczba planet do rozmieszczenia
    public Vector3 spawnArea = new Vector3(100, 100, 100); // Obszar, w którym bêd¹ rozmieszczane planety

    void Start()
    {
        SpawnPlanets();
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            // Generowanie losowej pozycji wewn¹trz zdefiniowanego obszaru
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Tworzenie planety w losowej pozycji
            Instantiate(planetPrefab, randomPosition, Quaternion.identity);
        }
    }
}
