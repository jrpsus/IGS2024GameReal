using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseScreen;
    public PlayerScript player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        pauseScreen = GameObject.Find("PauseMenu");
        pauseScreen.SetActive(false);
    }

    public void TogglePause()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            paused = true;
            Time.timeScale = 0.0f;
        }
        pauseScreen.SetActive(paused);
    }
    public void LoadScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.hp > 0f)
        {
            TogglePause();
        }
    }
}
