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
    public GameObject hitbox;
    //public Transform rightArm;
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
            sprite.sprite = null;
            sprite.color = new Color(1f, 1f, 1f, 0f);
            hitbox.transform.localPosition = new Vector3(33f, 4f, 0f);
            hitbox.transform.localScale = new Vector3(16f, 24f, 1f);
        }
        else
        {
            transform.localPosition = offset[playerScript.inv[playerScript.holding]];
            transform.localRotation = Quaternion.Euler(rotationOffset[playerScript.inv[playerScript.holding]].x, rotationOffset[playerScript.inv[playerScript.holding]].y, rotationOffset[playerScript.inv[playerScript.holding]].z);
            transform.localScale = scaleOffset[playerScript.inv[playerScript.holding]];
            sprite.sprite = inv.itemImage[playerScript.inv[playerScript.holding]];
            sprite.color = new Color(1f, 1f, 1f, 1f);
            if (playerScript.inv[playerScript.holding] == 0)
            {
                hitbox.transform.localPosition = new Vector3(33.5f, 19f, 0f);
                hitbox.transform.localScale = new Vector3(16f, 43f, 1f);
            }
            else if (playerScript.inv[playerScript.holding] == 1)
            {
                hitbox.transform.localScale = new Vector3(0f, 0f, 0f);
            }
            else if (playerScript.inv[playerScript.holding] == 2)
            {
                hitbox.transform.localPosition = new Vector3(33.5f, 21f, 0f);
                hitbox.transform.localScale = new Vector3(16f, 43f, 1f);
            }
        }
    }
}
