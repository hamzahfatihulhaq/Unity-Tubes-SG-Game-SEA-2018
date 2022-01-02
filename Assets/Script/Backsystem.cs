using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Backsystem : MonoBehaviour
{
    public string menu;
    public void BackGame()
    {
        SceneManager.LoadScene(menu);
    }
}
