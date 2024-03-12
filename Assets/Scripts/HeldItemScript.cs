using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemScript : MonoBehaviour
{
    public Vector3[] offset;
    public Vector3[] rotationOffset;
    public Vector3[] scaleOffset;
    public PlayerScript playerScript;
    public SpriteRenderer sprite;
    public Transform rightArm;
    public Inventory inv;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.inv[playerScript.holding] == -1)
        {
            sprite.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            transform.localPosition = rightArm.localPosition + offset[playerScript.inv[playerScript.holding]];
            transform.localRotation = Quaternion.Euler(rotationOffset[playerScript.inv[playerScript.holding]].x, rotationOffset[playerScript.inv[playerScript.holding]].y, rotationOffset[playerScript.inv[playerScript.holding]].z);
            transform.localScale = scaleOffset[playerScript.inv[playerScript.holding]];
            sprite.sprite = inv.itemImage[playerScript.inv[playerScript.holding]];
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
