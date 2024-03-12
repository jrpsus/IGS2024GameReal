using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerScript : MonoBehaviour
{
    public float hp = 1000;
    public float maxhp = 1000;
    public float cash = 0;
    public float movespeed;
    public float movespeedx;
    public float regenspeed;
    public int purchasePad;
    public int holding = 0;
    public GameObject cam;
    public Vector3 movement;
    public Rigidbody2D rb;
    public bool[] perks;
    public int[] inv;
    public int[] invc;
    public int[] invt;
    public PauseScript pause;
    Vector3 mx;
    Vector3 my;

    void Start()
    {
        cam = Camera.main.gameObject;
        rb = GetComponent<Rigidbody2D>();
        pause = GameObject.Find("GameData").GetComponent<PauseScript>();
    }

    void Update()
    {
        if (!pause.paused)
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
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                HoldItem(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                HoldItem(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                HoldItem(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                HoldItem(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                HoldItem(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                HoldItem(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                HoldItem(6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                HoldItem(7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                HoldItem(8);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                HoldItem(9);
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
    }
    
    public void HoldItem (int num)
    {
        holding = num;
    }

    public void SwapItem(int num, int num2)
    {
        invt[0] = inv[num];
        invt[1] = invc[num];
        inv[num] = inv[num2];
        invc[num] = invc[num2];
        inv[num2] = invt[0];
        invc[num2] = invc[1];
    }

    public void DropItem(int num)
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
