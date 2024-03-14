using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float projectileDamage;
    public float lifespan;
    public Rigidbody2D rb;
    void Awake()
    {
        Vector2 force = transform.up * speed;
        rb.velocity = force;
        //rb.AddForce(force);
    }
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Monster" && gameObject.tag == "Player Projectile")
        {
            MonsterScript monster = collision.gameObject.GetComponent<MonsterScript>();
            monster.hp -= projectileDamage * Random.Range(0.85f, 1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Monster Projectile")
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            player.hp -= projectileDamage * Random.Range(0.85f, 1f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Gates")
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Gates")
        //{
            //Destroy(gameObject);
        //}
    }
}
