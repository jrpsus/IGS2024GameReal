using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PlayerScript player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp <= 0f)
        {
            Time.timeScale = 0f;
        }
    }
}
