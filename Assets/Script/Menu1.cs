using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu1 : MonoBehaviour
{
    public string map1;
    public string map2;
    public string menu;
    public void StartMap1()
    {
        SceneManager.LoadScene(map1);
    }
    public void StartMap2()
    {
        SceneManager.LoadScene(map2);
    }
    public void BackGame()
    {
        SceneManager.LoadScene(menu);
    }
}
