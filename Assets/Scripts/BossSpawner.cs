using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab bossa
    public float spawnRadius = 10f; // Promieñ obszaru, w którym boss mo¿e siê zrespiæ
    public int enemiesToDestroy = 10; // Liczba zniszczonych przeciwników wymagana do pojawienia siê bossa

    private int enemiesDestroyed = 0; // Licznik zniszczonych przeciwników
    private bool bossSpawned = false; // Czy boss zosta³ ju¿ zrespiony

    // Metoda wywo³ywana, gdy przeciwnik zostanie zniszczony
    public void EnemyDestroyed()
    {
        if (bossSpawned) return; // Jeœli boss ju¿ zosta³ zrespiony, nie rób nic

        enemiesDestroyed++; // Zwiêksz licznik zniszczonych przeciwników
        Debug.Log("Zniszczono przeciwnika. Liczba zniszczonych: " + enemiesDestroyed);

        // SprawdŸ, czy liczba zniszczonych przeciwników osi¹gnê³a próg
        if (enemiesDestroyed >= enemiesToDestroy)
        {
            SpawnBoss(); // Respienie bossa
        }
    }

    // Metoda odpowiedzialna za respienie bossa
    private void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            // Wygeneruj losow¹ pozycjê w promieniu od punktu (0, 0, 0)
            Vector3 randomPosition = GetRandomPositionWithinRadius();

            // Respienie bossa
            Instantiate(bossPrefab, randomPosition, Quaternion.identity); // Zrespienie bossa
            Debug.Log("Boss zosta³ zrespiony w pozycji: " + randomPosition);

            bossSpawned = true; // Ustaw flagê, ¿e boss zosta³ zrespiony
        }
        else
        {
            Debug.LogError("Brak przypisanego prefab bossa.");
        }
    }

    // Metoda generuj¹ca losow¹ pozycjê w promieniu spawnRadius od punktu (0, 0, 0)
    private Vector3 GetRandomPositionWithinRadius()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius; // Losowy punkt na p³aszczyŸnie
        return new Vector3(randomCircle.x, 0f, randomCircle.y); // Przekszta³æ na pozycjê 3D (na wysokoœci 0)
    }
}
