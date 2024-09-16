using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target; // The final destination for the enemy (e.g., the player's base)
    private NavMeshAgent agent; // The NavMeshAgent component responsible for enemy movement

    void Start()
    {
        // Get the NavMeshAgent component attached to this game object
        agent = GetComponent<NavMeshAgent>();

        // Set the destination for the enemy to move towards the target (the base)
        agent.SetDestination(target.position);
    }

    void Update()
    {
        // Check if the enemy has reached the target (close enough to be considered at the destination)
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Destroy the enemy object when it reaches the target
            Destroy(gameObject);
        }
    }

    // This function is called when the enemy collides with another object (using a trigger)
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Home")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}



