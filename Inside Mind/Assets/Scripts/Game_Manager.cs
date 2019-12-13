using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Load_Level()
    {
        SceneManager.LoadScene(1);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Reset_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
