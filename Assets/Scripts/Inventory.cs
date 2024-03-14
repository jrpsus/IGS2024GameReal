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
    4 = perk
     */ 
    public float[] itemDamage/* = { 20f, 45f, 95f, 160f, 210f, 200f, 800f, 300f, 1000f, 1500f }*/;
    public float[] itemCooldown/* = { 0.5f, 0.8f, 1f, 1.5f, 0.9f, 0.6f, 0.5f, 0.2f, 1.5f, 1f }*/;
    public Sprite[] itemImage;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        
    }
}
