using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerScript player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        
    }
}
