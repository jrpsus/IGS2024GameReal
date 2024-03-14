using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public int type;
    public float yield;
    float cd = 1f;
    float lifespan = 15f;
    public Rigidbody2D rb;
    public GameObject player;
    public PlayerScript playerScript;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        lifespan = 15f;
        if (yield > 0f)
        {
            cd = 0f;
        }
    }
    private void Update()
    {
        cd -= Time.deltaTime;
        lifespan -= Time.deltaTime;
        if (Vector2.Distance(rb.position, player.transform.position) <= 2f)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector2 force = dir * 250 * Time.deltaTime;
            rb.AddForce(force);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (cd < 0 && collision.CompareTag("Player"))
        {
            if (type == 1)
            {
                playerScript.cash += yield;
            }
            Destroy(gameObject);
        }
    }
}
