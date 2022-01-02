using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    public int P1Life;
    public int P2Life;

    public GameObject P1Wins;
    public GameObject P2Wins;
    public GameObject Button;
    public GameObject Button2;

    public GameObject[] p1Hurths;
    public GameObject[] p2Hurths;

    public AudioSource hurtsound;

    public string Menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (P1Life <= 0)
        {
            Player1.SetActive(false);
            P2Wins.SetActive(true);
            Button.SetActive(true);
            Button2.SetActive(true);
        }

        if (P2Life <= 0)
        {
            Player2.SetActive(false);
            P1Wins.SetActive(true);
            Button.SetActive(true);
            Button2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Menu);
        }
    }


    public void PlayAgaint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void exit()
    {
        if (P1Wins.activeSelf || P2Wins.activeSelf)
        {
            Application.LoadLevel(0);

        }
    }
public void HurtP1()
    {
        P1Life -= 1;

        for (int i =  0;  i < p1Hurths.Length; i++)
        {
            if (P1Life > i)
            {
                p1Hurths[i].SetActive(true);
            }
            else
            {
                p1Hurths[i].SetActive(false);
            }
        }
        hurtsound.Play();
    }
    public void HurtP2()
    {
        P2Life -= 1;    

        for (int i = 0; i < p2Hurths.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hurths[i].SetActive(true);
            }
            else
            {
                p2Hurths[i].SetActive(false);
            }
        }
        hurtsound.Play();
    }
}
