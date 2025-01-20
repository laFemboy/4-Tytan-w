using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10, 0); // Pr�dko�� obrotu w stopniach na sekund�

    void Update()
    {
        // Obr�t planety
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
