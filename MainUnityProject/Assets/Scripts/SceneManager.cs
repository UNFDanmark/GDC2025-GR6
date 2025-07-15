using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager  : MonoBehaviour
{
    static float Sensitivity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        Sensitivity = Game
        UnityEngine.SceneManagement.SceneManager.LoadScene("Programmering");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
