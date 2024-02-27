using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float hp = 1000;
    public float maxhp = 1000;
    public float cash = 0;
    public float movespeed;
    public float movespeedx;
    public float regenspeed;
    public int holding = 0;
    public GameObject cam;
    public Vector3 movement;
    public Rigidbody2D rb;
    public bool[] perks;
    public string[] inv;
    public int[] invc;
    Vector3 mx;
    Vector3 my;

    void Start()
    {
        cam = Camera.main.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousepos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movespeed = 2 * movespeedx;
        }
        else
        {
            movespeed = movespeedx;
        }
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * movespeed, Input.GetAxisRaw("Vertical") * movespeed, 0);
        rb.AddForce(movement);
        cam.transform.position = transform.position - new Vector3(0, 0, 10);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        hp += regenspeed * Time.deltaTime;
        if (hp >= maxhp)
        {
            hp = maxhp;
        }
    }
    
    public void HoldItem (int num)
    {
        holding = num;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
