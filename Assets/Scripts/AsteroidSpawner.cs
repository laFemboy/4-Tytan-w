using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Tablica prefab�w asteroid do losowego wyboru
    public int numberOfAsteroids = 10; // Liczba asteroid do rozmieszczenia
    public Vector3 spawnArea = new Vector3(100, 100, 100); // Obszar, w kt�rym b�d� rozmieszczane asteroidy
    public float speed = 5f; // Pr�dko�� poruszania si� asteroid

    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            // Generowanie losowej pozycji wewn�trz zdefiniowanego obszaru
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            // Losowanie prefabrykat�w asteroid z tablicy
            GameObject selectedAsteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

            // Tworzenie asteroidy w losowej pozycji
            GameObject asteroid = Instantiate(selectedAsteroidPrefab, randomPosition, Quaternion.identity);

            // Dodawanie skryptu ruchu do asteroidy
            asteroid.AddComponent<AsteroidMover>().Initialize(speed);
        }
    }
}
