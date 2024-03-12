using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public int gatehp;
    public int gatemaxhp;
    public float repairTime;
    public float repairing;
    void Start()
    {
        gatehp = gatemaxhp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
