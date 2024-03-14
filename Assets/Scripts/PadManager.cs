using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PadManager : MonoBehaviour
{
    public PlayerScript player;
    public Inventory inventory;
    public GameObject[] pads;
    public Image image;
    public TextMeshProUGUI text;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.purchasePad >= 1)
        {
            image.color = new Color(0.62f, 0.13f, 0.08f, 1f);
            text.color = new Color(1f, 1f, 1f, 1f);
            PadScript pad = pads[player.purchasePad - 1].GetComponent<PadScript>();
            if (pad.type == 1)
            {
                text.text = "Stay on pad to repair gate";
            }
            else if (pad.type == 2)
            {
                text.text = "Press Space to buy " + inventory.itemName[pad.item] + " for $" + pad.value;
            }
        }
        else
        {
            image.color = new Color(0.62f, 0.13f, 0.08f, 0f);
            text.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
