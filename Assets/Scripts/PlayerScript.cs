using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float hp = 1000;
    public float maxhp = 1000;
    public float attack;
    public float attackCooldown;
    public float cash = 0;
    public float iFrames;
    public float movespeed;
    public float movespeedx;
    public float regenspeed;
    public int purchasePad;
    public float purchasePadTime;
    public int holding = 0;
    public GameObject cam;
    public GameObject gameOver;
    public Rigidbody2D[] projectiles;
    public Vector3 movement;
    public Rigidbody2D rb;
    public bool[] perks;
    public bool[] rooms;
    public int[] inv;
    public int[] invc;
    public int[] invt;
    public Animator anim;
    public Inventory inventory;
    public int[] animType;
    public PauseScript pause;
    public int state;
    Vector3 mx;
    Vector3 my;

    void Start()
    {
        cam = Camera.main.gameObject;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        rb = GetComponent<Rigidbody2D>();
        pause = GameObject.Find("GameData").GetComponent<PauseScript>();
        gameOver.SetActive(false);
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
            if (hp > 0f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            }
            hp += regenspeed * Time.deltaTime;
            if (Input.GetMouseButton(0) && attackCooldown <= 0f)
            {
                state = animType[inv[holding] + 1];
                anim.SetInteger("State", state);
                if (inv[holding] == 1)
                {
                    Cooldown();
                    Rigidbody2D clone;
                    clone = Instantiate(projectiles[0], transform.localPosition + (transform.up * 0.7f + transform.right * 0.7f), transform.rotation);
                    //clone.velocity = transform.TransformDirection(Vector3.up * clone.gameObject.GetComponent<ProjectileScript>().speed);
                    //clone.AddForce(transform.up * clone.gameObject.GetComponent<ProjectileScript>().speed * Time.deltaTime);
                }
                Cooldown();
            }
            else
            {
                anim.SetInteger("State", 0);
            }
            if (inv[holding] == -1)
            {
                attack = 10;
            }
            else
            {
                attack = inventory.itemDamage[inv[holding]];
            }
            if (hp >= maxhp)
            {
                hp = maxhp;
            }
            if (hp <= 0)
            {
                gameOver.SetActive(true);
            }
            iFrames -= Time.deltaTime;
            if (attackCooldown >= 0f)
            {
                attackCooldown -= Time.deltaTime;
            }
            else
            {
                state = 0;
            }
            if (purchasePadTime <= 0f)
            {
                purchasePad = 0;
            }
            else
            {
                purchasePadTime -= Time.deltaTime;
            }
        }
    }
    public void Cooldown()
    {
        if (attackCooldown <= 0f)
        {
            if (inv[holding] == -1)
            {
                attackCooldown = 0.48f;
            }
            else
            {
                attackCooldown = inventory.itemCooldown[inv[holding]] * 0.96f;
            }
        }
    }
    public bool HasItem(int id)
    {
        int slot = -1;
        for (int i = inv.Length - 1; i > -1; i--)
        {
            if (inv[i] == id && invc[i] >= 1)
            {
                slot = i;
            }
        }
        return slot >= 0;
    }
    public void GiveItem(int id)
    {
        if (FindEmptySpace() != -1)
        {
            int emptyslot = FindEmptySpace();
            inv[emptyslot] = id;
            invc[emptyslot] = 1;
        }
    }
    public void HoldItem (int num)
    {
        if (!pause.paused)
        {
            holding = num;
        }
    }
    public int FindEmptySpace()
    {
        int slot = -1;
        for (int i = inv.Length - 1; i > -1; i--)
        {
            if (inv[i] == -1 && invc[i] == 0)
            {
                slot = i;
            }
        }
        return slot;
    }

    public void SwapItem(int num, int num2)
    {
        if (!pause.paused)
        {
            invt[0] = inv[num];
            invt[1] = invc[num];
            inv[num] = inv[num2];
            invc[num] = invc[num2];
            inv[num2] = invt[0];
            invc[num2] = invc[1];
        }
    }

    public void DropItem(int num)
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster Fist")
        {

        }
    }
}
