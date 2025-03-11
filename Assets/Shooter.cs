using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Bullet prefab reference
    public Transform shootPoint;     // Launch point where bullets are instantiated
    public float shootRate = 5f;     // Time between each shot (in seconds)

    private float nextTimeToShoot = 0f;  // Track the next time to shoot
    private GameObject currentBullet;    // The bullet that will be reused

    void Start()
    {
        // Instantiate the bullet once and disable it initially
        currentBullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        currentBullet.SetActive(false);  // Disable it until it's needed
    }

    void Update()
    {
        // Check if enough time has passed to shoot (every 5 seconds)
        if (Time.time >= nextTimeToShoot)
        {
            ShootBullet();
            nextTimeToShoot = Time.time + shootRate; // Set the next time to shoot (5 seconds later)
        }
    }

    void ShootBullet()
    {
        if (currentBullet && shootPoint)
        {
            // Move the bullet to the shoot point and enable it
            currentBullet.transform.position = shootPoint.position;
            currentBullet.transform.rotation = shootPoint.rotation;
            currentBullet.SetActive(true);

            // Get the Rigidbody2D and apply velocity
            Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = shootPoint.up * 10f; // Bullet speed (10 units per second)
            }

            // Log for debugging
            Debug.Log("Bullet fired at: " + shootPoint.position);
        }
    }
}