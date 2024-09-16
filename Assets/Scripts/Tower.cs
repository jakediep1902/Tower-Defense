using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 5f; // The range within which the tower can target enemies
    public float fireRate = 1f; // The rate at which the tower shoots (1 shot per second)
    public GameObject bulletPrefab; // The bullet prefab that will be instantiated when shooting
    private float fireCountdown = 0f; // Countdown timer to control when the tower can fire again

    void Update()
    {
        // Find the closest enemy within the range
        Enemy target = FindClosestEnemy();

        // If a target is found and the fire countdown has reached zero or below
        if (target != null && fireCountdown <= 0f)
        {
            // Shoot the target
            Shoot(target);

            // Reset the fire countdown based on the fire rate
            fireCountdown = 1f / fireRate;
        }

        // Decrease the fire countdown over time
        fireCountdown -= Time.deltaTime;
    }

    void Shoot(Enemy enemy)
    {
        // Instantiate a bullet at the tower's position with no rotation (Quaternion.identity)
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Get the CurvedBullet component attached to the instantiated bullet
        CurvedBullet curvedBullet = bulletGO.GetComponent<CurvedBullet>();

        // If the bullet has the CurvedBullet component, make it seek the enemy
        if (curvedBullet != null)
        {
            curvedBullet.Seek(enemy); // The bullet will curve towards the enemy
        }
    }


    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>(); // Find all active enemies in the scene
        Enemy closestEnemy = null; // Variable to store the closest enemy
        float shortestDistance = Mathf.Infinity; // Set an initial very high distance
        Vector3 currentPosition = transform.position; // Position of the tower

        foreach (Enemy enemy in enemies)
        {
            // Calculate the distance between the tower and the enemy
            float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);

            // Check if this enemy is closer than the previously found one
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range) // Check if within range
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy; // Update the closest enemy
            }
        }

        return closestEnemy; // Return the closest enemy or null if no enemy found
    }
}
