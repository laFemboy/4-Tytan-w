using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed = 30f;          
    public float sprintMultiplier = 2f;   
    public float rotationSpeed = 50f;    

    void Update()
    {
        float moveForwardBackward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
            moveForwardBackward *= sprintMultiplier;

        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveUpDown = 0;

        if (Input.GetKey(KeyCode.Q))   
            moveUpDown = moveSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.E))   
            moveUpDown = -moveSpeed * Time.deltaTime;

        Vector3 movement = transform.forward * moveForwardBackward +
                           transform.right * moveLeftRight +
                           transform.up * moveUpDown;
        transform.position += movement;

        float pitch = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; 
        float yaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime; 
        float roll = 0;

        if (Input.GetKey(KeyCode.A))  
            roll = rotationSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.D))  
            roll = -rotationSpeed * Time.deltaTime;

        transform.Rotate(pitch, yaw, roll, Space.Self);
    }
}