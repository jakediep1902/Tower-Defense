using UnityEngine;

public class CurvedBullet : MonoBehaviour
{
    private Enemy target; // Target enemy the bullet will curve towards
    public float speed = 10f; // Speed of the bullet
    public float height = 5f; // Height of the curve

    private Vector3 startPoint; // Start position of the bullet
    private Vector3 endPoint; // Target position (enemy position)
    private float progress = 0f; // Progress along the curve

    // This function is called to make the bullet target an enemy
    public void Seek(Enemy _target)
    {
        target = _target;
        startPoint = transform.position; // The bullet's current position
        endPoint = target.transform.position; // The enemy's current position
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); // Destroy the bullet if there's no target
            return;
        }

        // Move along the curve
        progress += speed * Time.deltaTime;

        // Interpolate along the X and Z axes (linear)
        Vector3 currentPosition = Vector3.Lerp(startPoint, endPoint, progress);

        // Add the Y-axis height to create a curved trajectory
        float heightOffset = Mathf.Sin(Mathf.Clamp01(progress) * Mathf.PI) * height;
        currentPosition.y += heightOffset;

        // Update bullet's position
        transform.position = currentPosition;

        // Check if the bullet reached the target
        if (progress >= 1f)
        {
            HitTarget();
        }
    }

    // Logic to handle when the bullet hits the target
    void HitTarget()
    {
        // Damage the enemy or apply any other effect
        Destroy(gameObject); // Destroy the bullet after hitting the target
    }
}
