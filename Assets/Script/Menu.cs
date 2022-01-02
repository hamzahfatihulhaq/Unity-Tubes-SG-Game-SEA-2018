using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string MainGameScreen;
    public string KeyMovement;
    
    public void StartGame()
    {
        SceneManager.LoadScene(MainGameScreen);
    }
    public void MovementGame()
    {
        SceneManager.LoadScene(KeyMovement);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}