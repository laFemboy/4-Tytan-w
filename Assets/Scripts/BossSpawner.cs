using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab bossa
    public float spawnRadius = 10f; // Promie� obszaru, w kt�rym boss mo�e si� zrespi�
    public int enemiesToDestroy = 10; // Liczba zniszczonych przeciwnik�w wymagana do pojawienia si� bossa

    private int enemiesDestroyed = 0; // Licznik zniszczonych przeciwnik�w
    private bool bossSpawned = false; // Czy boss zosta� ju� zrespiony

    // Metoda wywo�ywana, gdy przeciwnik zostanie zniszczony
    public void EnemyDestroyed()
    {
        if (bossSpawned) return; // Je�li boss ju� zosta� zrespiony, nie r�b nic

        enemiesDestroyed++; // Zwi�ksz licznik zniszczonych przeciwnik�w
        Debug.Log("Zniszczono przeciwnika. Liczba zniszczonych: " + enemiesDestroyed);

        // Sprawd�, czy liczba zniszczonych przeciwnik�w osi�gn�a pr�g
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
            // Wygeneruj losow� pozycj� w promieniu od punktu (0, 0, 0)
            Vector3 randomPosition = GetRandomPositionWithinRadius();

            // Respienie bossa
            Instantiate(bossPrefab, randomPosition, Quaternion.identity); // Zrespienie bossa
            Debug.Log("Boss zosta� zrespiony w pozycji: " + randomPosition);

            bossSpawned = true; // Ustaw flag�, �e boss zosta� zrespiony
        }
        else
        {
            Debug.LogError("Brak przypisanego prefab bossa.");
        }
    }

    // Metoda generuj�ca losow� pozycj� w promieniu spawnRadius od punktu (0, 0, 0)
    private Vector3 GetRandomPositionWithinRadius()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius; // Losowy punkt na p�aszczy�nie
        return new Vector3(randomCircle.x, 0f, randomCircle.y); // Przekszta�� na pozycj� 3D (na wysoko�ci 0)
    }
}
