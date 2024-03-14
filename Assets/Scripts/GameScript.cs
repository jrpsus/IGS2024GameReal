using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public float timeRemaining;
    public int monstersRemaining;
    public int[] monstersQueue;
    public int round = 0;
    public int[] zombieThugs;
    public int[] zombieFighters;
    public int[] zombieShooters;
    public int[] zombieBabies;
    public int[] zombieAliens;
    public int[] zombieArsonists;
    public int[] zombieFreezers;
    public bool[] gateUnlocked;
    public GameObject player;
    public PlayerScript playerScript;
    public GameObject[] monsters;
    public GameObject[] moneySprites;
    public Vector3 mouse;
    public Vector2[] spawnPosition;
    public Vector2[] spawnRange;

    void Start()
    {
        InvokeRepeating("SpawnCycle", 5f, 5f);
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    void Update()
    {
        mouse = Input.mousePosition;
        if (monstersRemaining <= 0)
        {
            if (timeRemaining <= 0f)
            {
                timeRemaining = round + 9f;
                playerScript.cash += round * 3f;
                playerScript.hp += 100f;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0f)
                {
                    StartNextRound();
                }
            }
        }
    }
    public void StartNextRound()
    {
        monstersQueue[0] += zombieThugs[round];
        monstersRemaining += zombieThugs[round];
        monstersQueue[1] += zombieFighters[round];
        monstersRemaining += zombieFighters[round];
        monstersQueue[2] += zombieShooters[round];
        monstersRemaining += zombieShooters[round];
        round += 1;
    }
    public void SpawnCycle()
    {
        for (int i = 0; i < monstersQueue.Length; i++)
        {
            if (monstersQueue[i] >= 1)
            {
                Instantiate(monsters[i], spawnPosition[0/*Random.Range(0, 1)*/] + new Vector2(Random.Range(spawnRange[0].x * -1, spawnRange[0].x), Random.Range(spawnRange[0].y * -1, spawnRange[0].y)), Quaternion.identity);
                monstersQueue[i] -= 1;
            }
        }
    }
}
