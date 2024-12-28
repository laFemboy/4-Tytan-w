using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed;          
    public float sprintMultiplier;   
    public float rotationSpeed;
    public float rollAcceleration;
    public float rollDamping;

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

        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveHorizontal = 0;
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpDown = 0;

        Vector3 movement = new Vector3(moveHorizontal, moveUpDown, moveVertical);
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.Self);


        float pitch = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float yaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        //float roll = 0;

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
    }
}