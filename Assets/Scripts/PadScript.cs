using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PadScript : MonoBehaviour
{
    public int id;
    public int type; // 1 = gate, 2 = item
    public GateScript gate;
    public int item;
    public float value;
    public PlayerScript player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.purchasePad = id;
            player.purchasePadTime = 0.2f;
            if (type == 2)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (player.cash >= value && !player.HasItem(item))
                    {
                        player.GiveItem(item);
                        player.cash -= value;
                    }
                }
            }
            else if (type == 1 && gate.gatehp < gate.gatemaxhp)
            {
                gate.repairing -= Time.deltaTime;
                if (gate.repairing <= 0f)
                {
                    //player.cash += Mathf.Floor(((gate.gatemaxhp - gate.gatehp) * gate.repairTime) * value * 100) / 100;
                    gate.gatehp = gate.gatemaxhp;
                    gate.repairing = gate.repairTime;
                }
            }
        }
    }
}
