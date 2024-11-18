using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; 
    public int numberOfAsteroids = 10; 
    public Vector3 spawnArea = new Vector3(100, 100, 100); 
    public float speed = 5f; 

    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject selectedAsteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

            GameObject asteroid = Instantiate(selectedAsteroidPrefab, randomPosition, Quaternion.identity);

            asteroid.AddComponent<AsteroidMover>().Initialize(speed);
        }
    }
}
