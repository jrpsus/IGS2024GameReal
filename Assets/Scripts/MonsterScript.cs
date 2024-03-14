using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class MonsterScript : MonoBehaviour
{
    public float hp;
    public float maxhp;
    public float attack;
    public float attackCooldown;
    public float attackRealCooldown;
    public float iFrames;
    public int type;
    public int[] moneyDropped;
    public bool punchingGate = false;
    public Transform player;
    public GameObject hitbox;
    public GameObject projectile;
    public GameScript game;
    public Collider2D hitboxCollision;
    public PlayerScript playerScript;
    public float speed;
    public float nextWaypointDistance = 0.5f;
    public float distanceToPlayer;
    public int state;
    public Animator anim;
    public Inventory inventory;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        game = GameObject.Find("GameData").GetComponent<GameScript>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, player.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        Vector3 playerpos = player.transform.position;
        //Vector2 dir = (playerpos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        distanceToPlayer = Vector2.Distance(rb.position, player.position);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if (!punchingGate)
        {
            anim.SetInteger("State", 0);
            if (type == 1 || type == 2)
            {
                if (distanceToPlayer <= 2)
                {
                    anim.SetInteger("State", type);
                }
            }
            else if (type == 3)
            {
                if (distanceToPlayer <= 10)
                {
                    anim.SetInteger("State", 3);
                    if (attackCooldown <= 0f)
                    {
                        Instantiate(projectile, transform.localPosition + (transform.up * 0.7f + transform.right * transform.localScale.x * 35f), transform.rotation);
                        attackCooldown = attackRealCooldown;
                    }
                }
            }
        }
        iFrames -= Time.deltaTime;
        if (attackCooldown >= 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (hp <= 0)
        {
            Die();
        }
        FlipSprite(direction);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Fist" && playerScript.state >= 1 && iFrames <= 0f)
        {
            hp -= playerScript.attack * Random.Range(0.85f, 1f);
            iFrames = playerScript.attackCooldown;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gates")
        {
            if (collision.gameObject.GetComponent<GateScript>().gatehp > 0f)
            {
                punchingGate = true;
                if (type == 1 || type == 2)
                {
                    anim.SetInteger("State", type);
                }
            }
            else
            {
                punchingGate = false;
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gates")
        {
            punchingGate = false;
        }
    }
    public void Die()
    {
        game.monstersRemaining -= 1;
        for (int i = 0; i < moneyDropped.Length; i++)
        {
            for (int j = 0; j < moneyDropped[i]; j++)
            {
                Instantiate(game.moneySprites[i], transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }
    void FlipSprite(Vector2 direction)
    {
        if (direction.x > 0)
            transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-0.02f, 0.02f, 0.02f);
    }
}
