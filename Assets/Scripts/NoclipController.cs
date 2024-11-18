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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); 

        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveY = 0;

        if (Input.GetKey(KeyCode.E))
        {
            moveY = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveY = -1;
        }

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * boostMultiplier : speed;

        Vector3 movement = transform.right * moveX + transform.up * moveY + transform.forward * moveZ;
        transform.position += movement * currentSpeed * Time.deltaTime;
    }
}
