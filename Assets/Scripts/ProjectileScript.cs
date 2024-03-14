using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float projectileDamage;
    public Rigidbody2D rb;
    
    void Update()
    {
        Vector2 force = transform.up * speed * Time.deltaTime;
        rb.AddForce(force);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Monster")
        {
            MonsterScript monster = collision.gameObject.GetComponent<MonsterScript>();
            monster.hp -= projectileDamage * Random.Range(0.85f, 1f);
            Destroy(gameObject);
        }
    }
}
