using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemScript : MonoBehaviour
{
    public Vector3[] offset;
    public float[] rotationOffset;
    public Vector3[] scaleOffset;
    public PlayerScript playerScript;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset[playerScript.inv[playerScript.holding]];
        transform.rotation = new Quaternion(0f, 0f, rotationOffset[playerScript.inv[playerScript.holding]], 0f);
        transform.localScale = scaleOffset[playerScript.inv[playerScript.holding]];
    }
}
