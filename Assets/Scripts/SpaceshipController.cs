using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier;
    public float rotationSpeed;
    public float rollAcceleration;
    public float rollDamping;

    public GameObject laserPrefab; // Prefab lasera
    public Transform laserSpawnPoint; // Punkt, z kt�rego wystrzeliwany jest laser
    public float laserSpeed = 20f; // Pr�dko�� lasera
    public float laserLifeTime = 2f; // Czas �ycia lasera

    private float currentSpeed;
    private float currentRollVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintMultiplier : moveSpeed;

        // Ruch statku
        float moveHorizontal = 0;
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpDown = 0;

        Vector3 movement = new Vector3(moveHorizontal, moveUpDown, moveVertical);
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.Self);

        // Rotacja statku
        float pitch = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float yaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentRollVelocity += rollAcceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentRollVelocity -= rollAcceleration * Time.deltaTime;
        }
        else
        {
            if (currentRollVelocity > 0)
                currentRollVelocity -= rollDamping * Time.deltaTime;
            else if (currentRollVelocity < 0)
                currentRollVelocity += rollDamping * Time.deltaTime;

            if (Mathf.Abs(currentRollVelocity) < 0.1f)
                currentRollVelocity = 0f;
        }

        currentRollVelocity = Mathf.Clamp(currentRollVelocity, -rotationSpeed, rotationSpeed);
        transform.Rotate(pitch, yaw, currentRollVelocity * Time.deltaTime, Space.Self);

        // Strzelanie laserami
        if (Input.GetMouseButtonDown(0)) // Lewy przycisk myszy
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        // Sprawdzenie, czy prefab lasera i punkt strzału są przypisane
        if (laserPrefab != null && laserSpawnPoint != null)
        {
            // Tworzymy laser w punkcie startowym
            GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);

            // Pobieramy Rigidbody lasera, aby nadawać mu prędkość
            Rigidbody laserRb = laser.GetComponent<Rigidbody>();

            if (laserRb != null)
            {
                // Nadajemy laserowi prędkość w kierunku, w którym patrzy statek
                laserRb.linearVelocity = transform.forward * laserSpeed; // Zamiast laserSpawnPoint.forward, używamy transform.forward
            }

            // Usuwamy laser po określonym czasie życia
            Destroy(laser, laserLifeTime);
        }
    }

}
