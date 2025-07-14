using UnityEngine;
using UnityEngine.Events;
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

    public Transform facingPoint;
    public Vector3 lookDirection3D;
    public Vector3 lookDirection2D;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseInteraction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.jumpscared)
        {
            transform.LookAt(MonsterScript.instance.transform);
        }
        else
        {
            Vector2 mouseDelta = mouseInteraction.ReadValue<Vector2>();
            verticalAngle -= mouseDelta.y * ySensitivity;
            verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
            horizontalAngle += mouseDelta.x * xSensitivity;
            transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
            lookDirection3D = facingPoint.transform.position - transform.position;
            lookDirection2D = new Vector3(lookDirection3D.x, 0, lookDirection3D.z).normalized;
        }
        
    }
}
