using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    private Vector3 movementDirection;
    private float speed;

    public void Initialize(float asteroidSpeed)
    {
        speed = asteroidSpeed;

        movementDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized; 
    }

    void Update()
    {
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
