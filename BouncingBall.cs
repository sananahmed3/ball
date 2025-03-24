using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float initialSpeed = 5f;
    public float gravity = 9.81f;
    public float bounceDamping = 0.8f; // Reduce speed after each bounce

    private Vector3 velocity;

    public Transform ground;
    public Transform sphere;
    void Start()
    {
        // Give the ball an initial upward velocity
        velocity = new Vector3(0, initialSpeed, 0);
    }

    void Update()
    {
        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Move the ball
        transform.position += velocity * Time.deltaTime;



        //Bounds bounds = ground.GetComponent<Renderer>().bounds;

        // The diameter is the longest distance across the cube.
        // For a perfectly uniform cube, all sides are equal, so any diagonal across the cube will work.
        // We'll calculate the diagonal of the bounding box.
        //float diameter = bounds.size.magnitude; // Magnitude of the bounds size vector is the diagonal.

        //Bounds bounds = ground.GetComponent<Renderer>().bounds;
        //float height = bounds..y;

        // The height of a sphere is its diameter, which is the size in the y-axis.
        //float height = ground.transform.position.y;






        // Check for ground collision (assuming ground is at y = 0)
        if (transform.position.y <= 0)
        {
            // Reverse the vertical velocity and apply damping
            velocity.y = -velocity.y * bounceDamping;

            // Prevent the ball from going below the ground
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }





        void OnCollisionEnter(Collision collision)
        {
            // This function is called when the cube collides with another object.

            // Access the GameObject that the cube collided with.
            GameObject otherObject = collision.gameObject;

            // Access the contact points of the collision.
            ContactPoint[] contacts = collision.contacts;

            // Perform actions based on the collision.
            Debug.Log("Cube collided with: " + otherObject.name);

            // Example: Check if the other object has a specific tag.
            if (otherObject.CompareTag("Ground"))
            {
                Debug.Log("Cube collided with the ground.");
                // Perform specific actions when colliding with the ground.
            }

            // Example: Access the contact points.
            foreach (ContactPoint contact in contacts)
            {
                Debug.Log("Contact point: " + contact.point);
                Debug.Log("Normal: " + contact.normal);
                //Use contact.point and contact.normal to get information about where the collision happened.
            }

            // Example: Destroy the other object.
            // Destroy(otherObject);

            // Example: Add a force to the cube.
            // GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Impulse);

            // Example: Change the cube's color.
            // GetComponent<Renderer>().material.color = Color.red;
        }
    }


}

