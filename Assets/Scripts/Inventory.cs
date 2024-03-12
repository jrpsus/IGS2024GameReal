using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public PlayerScript player;
    public string[] itemName/* = { "Knife", "Shortbow", "Cane", "Crossbow", "Frying Pan", "Handgun", "Giant Sword", "Assault Rifle", "Grenade", "Battlestaff" }*/;
    public int[] itemType/* = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }*/;
    /*itemType
    1 = weapon
    2 = ammunition
    3 = consumable
     */ 
    public float[] itemDamage/* = { 10f, 40f, 65f, 90f, 110f, 200f, 800f, 300f, 1000f, 1500f }*/;
    public float[] itemCooldown/* = { 0.5f, 1.2f, 1f, 1.5f, 0.9f, 0.6f, 0.5f, 0.2f, 1.5f, 1f }*/;
    public Sprite[] itemImage;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        
    }
}
