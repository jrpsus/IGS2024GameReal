using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject player;
    public GameScript game;
    public PlayerScript playerScript;
    public Image healthFill;
    public TextMeshProUGUI[] text;
    void Start()
    {
        player = GameObject.Find("Player");
        game = GameObject.Find("GameData").GetComponent<GameScript>();
        //healthFill = GameObject.Find("HPGreen").GetComponent<Image>();
        playerScript = player.GetComponent<PlayerScript>();
    }
    void Update()
    {
        text[0].text = Mathf.Floor(playerScript.hp) + "/" + Mathf.Floor(playerScript.maxhp);
        text[1].text = "$" + playerScript.cash;
        text[2].text = "Round " + game.round;
        healthFill.fillAmount = playerScript.hp / playerScript.maxhp;
    }
}
