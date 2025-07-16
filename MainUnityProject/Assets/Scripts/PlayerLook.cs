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
    public float verticalAngle;
    public float horizontalAngle;
    public float minSensitivity, maxSensitivity;

    public Transform facingPoint;
    public Vector3 lookDirection3D;
    public Vector3 lookDirection2D;
    public InputAction upArr, downArr;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseInteraction.Enable();
        upArr.Enable();
        downArr.Enable();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.jumpscared)
        {
            transform.LookAt(MonsterScript.instance.jumpscarePoint.transform);
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

        if (upArr.IsPressed())
        {
            xSensitivity += 0.3f * Time.deltaTime;
            ySensitivity += 0.3f  * Time.deltaTime;
            xSensitivity = Mathf.Min(xSensitivity, maxSensitivity);
            ySensitivity = Mathf.Min(ySensitivity, maxSensitivity);
        } 
        if (downArr.IsPressed())
        {
            xSensitivity -= 0.3f  * Time.deltaTime;
            ySensitivity -= 0.3f  * Time.deltaTime;
            xSensitivity = Mathf.Max(xSensitivity, minSensitivity);
            ySensitivity = Mathf.Max(ySensitivity, minSensitivity);
        } 
    }
}
