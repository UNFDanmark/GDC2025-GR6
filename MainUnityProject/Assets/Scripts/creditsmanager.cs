using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Creditsmanager : MonoBehaviour
{
    public InputAction esc;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        esc.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (esc.triggered)
        {
            Cursor.lockState = CursorLockMode.None;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen");
        }
    }
}
