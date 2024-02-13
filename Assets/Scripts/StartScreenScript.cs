using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartScreenScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color color;
    public int buttonType;
    public int page;
    public StartScreenMain main;
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        color = text.color;
        color.a = 0;
        main = GameObject.Find("StartScreenManager").GetComponent<StartScreenMain>();
    }

    void Update()
    {
        text.color = color;
        if (color.a >= 1)
        {
            color.a = 1;
        }
        else
        {
            if (main.starting)
            {
                color.a -= Time.deltaTime / 2;
            }
            else
            {
                color.a += Time.deltaTime / 2;
            }
        }
    }
}
