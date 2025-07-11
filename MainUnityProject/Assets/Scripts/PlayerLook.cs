using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public InputAction mouseInteraction;
    public float xSensitivity;
    public float ySensitivity;
    public float minVerticalAngle;
    public float maxVerticalAngle;
    float verticalAngle;
    float horizontalAngle;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseInteraction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDelta = mouseInteraction.ReadValue<Vector2>();
        verticalAngle -= mouseDelta.y * ySensitivity;
        verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
        horizontalAngle += mouseDelta.x * xSensitivity;
        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
        
    }
}
