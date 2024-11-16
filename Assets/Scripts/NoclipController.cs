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
        // Ukryj kursor i zablokuj go na �rodku ekranu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Znajd� kamer� jako dziecko tego obiektu
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // Obracanie kamery za pomoc� myszy
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ograniczenie k�ta pionowego

        // Obr�t kamery w pionie
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Obr�t ca�ego gracza w poziomie
        transform.Rotate(Vector3.up * mouseX);

        // Pobranie wej�cia z klawiatury
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;

        // Poruszanie w g�r� i w d� za pomoc� klawiszy Q i E
        if (Input.GetKey(KeyCode.E))
        {
            moveY = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveY = -1;
        }

        // Sprawdzenie, czy gracz chce przyspieszy� (np. trzymaj�c lewy Shift)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * boostMultiplier : speed;

        // Przesuni�cie gracza w oparciu o wej�cia
        Vector3 movement = transform.right * moveX + transform.up * moveY + transform.forward * moveZ;
        transform.position += movement * currentSpeed * Time.deltaTime;
    }
}
