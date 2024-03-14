using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamageScript : MonoBehaviour
{
    public float damage;
    public MonsterScript monster;
    public PlayerScript player;
    public GateScript gate;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        damage = monster.attack;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.iFrames <= 0)
        {
            player.hp -= damage * Random.Range(0.85f, 1f);
            monster.attackCooldown = monster.attackRealCooldown * 0.96f;
            player.iFrames = monster.attackCooldown;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gates" && monster.attackCooldown <= 0)
        {
            gate = collision.gameObject.GetComponent<GateScript>();
            if (gate != null)
            {
                gate.gatehp -= damage * Random.Range(0.85f, 1f);
                monster.attackCooldown = monster.attackRealCooldown * 0.96f;
            }
        }
    }
}
