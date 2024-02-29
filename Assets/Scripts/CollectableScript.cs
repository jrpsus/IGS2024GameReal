using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public int type;
    public float yield;
    float cd = 1;
    public PlayerScript player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    private void Update()
    {
        cd -= Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (cd < 0 && collision.CompareTag("Player"))
        {
            if (type == 1)
            {
                player.cash += yield;
            }
            Destroy(gameObject);
        }
    }
}
