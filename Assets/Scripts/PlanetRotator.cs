using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0); // Prêdkoœæ obrotu w stopniach na sekundê

    void Update()
    {
        // Obrót planety
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
