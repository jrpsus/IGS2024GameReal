using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
{
    public float hp;
    public float maxhp;
    /*public Transform player;            // Reference to the player GameObject
    public float movementSpeed = 5f;    // Speed at which the enemy moves

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Initialize the NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        // Make sure the player is not null
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
        else
        {
            // Set the destination to the player's initial position
            navMeshAgent.SetDestination(player.position);
        }
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.position);

        
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }*/
}
