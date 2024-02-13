using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {

    }
}
