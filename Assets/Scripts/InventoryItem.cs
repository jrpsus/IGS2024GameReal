using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public int id;
    public PlayerScript player;
    public Inventory inv;
    public Image image;
    public Image frame;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.holding == id)
        {
            frame.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            frame.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        }
        if (player.inv[id] >= 0)
        {
            image.sprite = inv.itemImage[player.inv[id]];
            image.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            image.sprite = null;
            image.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
