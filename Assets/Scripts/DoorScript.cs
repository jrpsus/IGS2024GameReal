using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animation anim;
    public Vector3 pos;
    void Start()
    {
        transform.position = pos;
    }
    public void Open()
    {
        anim.Play();
    }
}
