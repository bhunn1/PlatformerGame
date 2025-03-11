using UnityEngine;

public class DropProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;  // Projectile to drop
    public Transform dropPoint;          // The position where the projectile will drop from (e.g., player's position)
    public float dropSpeed = 5f;         // Speed at which the projectile drops

    void Update()
    {
        // Check if the player presses the "E" key to drop the projectile
        if (Input.GetKeyDown(KeyCode.P))
        {
            DropProjectileOnEnemies();
        }
    }

    void DropProjectileOnEnemies()
    {
        if (projectilePrefab && dropPoint)
        {
            // Instantiate the projectile at the drop point (e.g., the player's position)
            GameObject droppedProjectile = Instantiate(projectilePrefab, dropPoint.position, Quaternion.identity);

            // Add downward velocity to simulate dropping
            Rigidbody2D rb = droppedProjectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(0, -dropSpeed);  // Drop downward (negative Y-axis)
            }

            Debug.Log("Projectile dropped at: " + dropPoint.position);
        }
    }
}
