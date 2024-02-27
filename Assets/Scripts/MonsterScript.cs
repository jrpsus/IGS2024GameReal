using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;            // Reference to the player GameObject
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
            Debug.LogError("Player not assigned to EnemyController!");
        }
        else
        {
            // Set the destination to the player's initial position
            navMeshAgent.SetDestination(player.position);
        }
    }

    void Update()
    {
        // Update the destination to the player's current position
        navMeshAgent.SetDestination(player.position);

        // Move towards the destination at the specified speed
        // If you want the enemy to rotate towards the player, uncomment the line below
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
