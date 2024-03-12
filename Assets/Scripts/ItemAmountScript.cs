using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemAmountScript : MonoBehaviour
{
    public PlayerScript player;
    public int id;
    public TextMeshProUGUI text;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        text = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        if (player.invc[id] >= 2)
        {
            text.text = player.invc[id].ToString();
            text.color = new Color(0, 0, 0, 1f);
        }
        else
        {
            text.color = new Color(0, 0, 0, 0f);
        }
    }
}
