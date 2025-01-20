using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier;
    public float rotationSpeed;
    public float rollAcceleration;
    public float rollDamping;
    public GameObject laserPrefab; // Prefab lasera
    public Transform laserSpawnPoint; // Punkt, z którego laser bêdzie wystrzeliwany

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

        // Wystrzeliwanie lasera
        if (Input.GetMouseButtonDown(0)) // Lewy przycisk myszy
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        if (laserPrefab != null && laserSpawnPoint != null)
        {
            Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
        }
    }
}