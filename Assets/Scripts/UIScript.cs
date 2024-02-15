using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject player;
    public PlayerScript playerScript;
    public TextMeshProUGUI[] text;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }
    void Update()
    {
        text[0].text = Mathf.Floor(playerScript.hp) + "/" + Mathf.Floor(playerScript.maxhp);
        text[1].text = "$" + playerScript.cash;
    }
}
