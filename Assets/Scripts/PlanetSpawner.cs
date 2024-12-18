using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public int numberOfPlanets;
    public Vector3 spawnArea = new Vector3(100, 100, 100);

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

            GameObject newPlanet = Instantiate(planetPrefab, randomPosition, Quaternion.identity);

            Renderer renderer = newPlanet.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(
                    Random.Range(0f, 1f), 
                    Random.Range(0f, 1f), 
                    Random.Range(0f, 1f)  
                );
            }
        }
    }
}
