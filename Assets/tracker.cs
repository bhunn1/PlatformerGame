using UnityEngine;

public class Tracker : MonoBehaviour
{
    public float rotationSpeed = 200f; // Adjust for smooth tracking
    public float fieldOfViewAngle = 120f; // Define field of view
    public float trackingRange = 25f; // Max distance to track a fuel can

    void FixedUpdate()
    {
        TrackClosestTarget();
    }

    private void TrackClosestTarget()
    {
        GameObject[] fuelCans = GameObject.FindGameObjectsWithTag("Kevin");
        if (fuelCans.Length == 0) return; // No fuel cans found

        GameObject closestFuelCan = null;
        float closestDistance = Mathf.Infinity;

        // Find the closest fuel can
        foreach (GameObject fuelCan in fuelCans)
        {
            float distance = Vector2.Distance(fuelCan.transform.position, transform.position);
            if (distance < closestDistance && distance < trackingRange)
            {
                closestDistance = distance;
                closestFuelCan = fuelCan;
            }
        }

        if (closestFuelCan != null)
        {
            Debug.DrawRay(transform.position, (closestFuelCan.transform.position - transform.position), Color.red); // Ray will be drawn in red
        }

        // Rotate towards the closest fuel can
        if (closestFuelCan != null)
        {
            RotateTowards(closestFuelCan);
        }
    }

    private void RotateTowards(GameObject target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        Vector2 yAxis = transform.up;
        float dot = Vector2.Dot(yAxis, direction);
        float angle = Vector2.Angle(yAxis, direction);
        Vector3 rotationAxis = Vector3.Cross(transform.up, direction);

        if (angle < fieldOfViewAngle / 2) // Check if it's within FOV
        {
            int clockwise = rotationAxis.z < 0 ? -1 : 1;
            float step = rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, Mathf.Min(angle, step) * clockwise);
        }
    }
}
