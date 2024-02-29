using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreenMain : MonoBehaviour
{
    public int menuPage = 0;
    public bool starting = false;
    public float startTime = 2;
    void Start()
    {
        menuPage = 0;
        starting = false;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (starting)
        {
            startTime -= Time.deltaTime;
            if (startTime <= 0f)
            {
                LoadScene("Game");
                startTime = 999;
            }
        }
    }
    public void ChangePage(int p)
    {
        if (p >= 0)
        {
            menuPage = p;
        }
        if (p == -1)
        {
            starting = true;
        }
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
