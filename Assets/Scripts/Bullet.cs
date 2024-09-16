using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Enemy target; // The target enemy that the bullet is seeking

    public float speed = 10f; // Speed at which the bullet travels

    // Function to set the target for the bullet
    public void Seek(Enemy _target)
    {
        target = _target; // Assign the target passed into the function
    }

    void Update()
    {
        // If the target no longer exists (e.g., it has been destroyed), destroy the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Calculate the direction from the bullet's current position to the target's position
        Vector3 direction = target.transform.position - transform.position;

        // Calculate the distance the bullet can travel in this frame
        float distanceThisFrame = speed * Time.deltaTime;

        // If the bullet is close enough to the target to hit it this frame
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget(); // Call the function to handle hitting the target
            return;
        }

        // Move the bullet towards the target
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    // Function to handle what happens when the bullet hits the target
    void HitTarget()
    {
        Destroy(gameObject); // Destroy the bullet when it hits the target
    }
}
