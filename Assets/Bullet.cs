using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the projectile

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component for movement
        rb = GetComponent<Rigidbody2D>();

        // Apply force to launch the projectile
        rb.linearVelocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collision with the shooter or the ground
        if (collision.gameObject.CompareTag("Shooter") || collision.gameObject.CompareTag("Ground"))
        {
            return;
        }

        // Deactivate the bullet instead of destroying it
        gameObject.SetActive(false);
    }

    // Optional: Reset the bullet for reuse
    public void ResetBullet(Vector2 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        gameObject.SetActive(true);  // Activate it again for reuse
    }
}