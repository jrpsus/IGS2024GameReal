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
    public float alpha;
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        color = text.color;
        color.a = 0;
        alpha = 0;
        main = GameObject.Find("StartScreenManager").GetComponent<StartScreenMain>();
    }

    void Update()
    {
        text.color = color;
        if (alpha > 1)
        {
            alpha = 1;
        }
        else
        {
            if (main.starting)
            {
                alpha -= Time.deltaTime / 2;
            }
            else
            {
                alpha += Time.deltaTime / 2;
            }
        }
        color.a = alpha;
    }
}
