using UnityEngine;

public class NoclipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float boostMultiplier = 3.0f;
    public float mouseSensitivity = 100.0f;

    private float rotationX = 0.0f;
    private Transform cameraTransform;

    void Start()
    {
        // Ukryj kursor i zablokuj go na œrodku ekranu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // ZnajdŸ kamerê jako dziecko tego obiektu
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // Obracanie kamery za pomoc¹ myszy
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ograniczenie k¹ta pionowego

        // Obrót kamery w pionie
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Obrót ca³ego gracza w poziomie
        transform.Rotate(Vector3.up * mouseX);

        // Pobranie wejœcia z klawiatury
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;

        // Poruszanie w górê i w dó³ za pomoc¹ klawiszy Q i E
        if (Input.GetKey(KeyCode.E))
        {
            moveY = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveY = -1;
        }

        // Sprawdzenie, czy gracz chce przyspieszyæ (np. trzymaj¹c lewy Shift)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * boostMultiplier : speed;

        // Przesuniêcie gracza w oparciu o wejœcia
        Vector3 movement = transform.right * moveX + transform.up * moveY + transform.forward * moveZ;
        transform.position += movement * currentSpeed * Time.deltaTime;
    }
}
