using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager  : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject logo, controlsmenu, playbutoon, quitbutton, controlsbutton, backbutton;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gametest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OpenControlsMenu()
    {
        logo.SetActive(false);
        playbutoon.SetActive(false);
        quitbutton.SetActive(false);
        controlsbutton.SetActive(false);
        backbutton.SetActive(true);
        controlsmenu.SetActive(true);
        logo.SetActive(false);
    }
    
    public void CloseControlsMenu()
    {
        logo.SetActive(true);
        playbutoon.SetActive(true);
        quitbutton.SetActive(true);
        controlsbutton.SetActive(true);
        backbutton.SetActive(false);
        controlsmenu.SetActive(false);
        logo.SetActive(true);
    }
        
}
