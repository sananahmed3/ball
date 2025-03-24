using UnityEngine;

public class spherecubecollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the other object is a cube.
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Sphere collided with a cube: " + collision.gameObject.name);

            // Access the cube GameObject.
            GameObject cube = collision.gameObject;

            // Access collision details (e.g., contact points).
            ContactPoint[] contacts = collision.contacts;
            foreach (ContactPoint contact in contacts)
            {
                Debug.Log("Collision Point: " + contact.point);
                Debug.Log("Collision Normal: " + contact.normal);
            }

            // Example: Change the cube's color.
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = Color.red;
            }

            // Example: Add force to the sphere.
            Rigidbody sphereRigidbody = GetComponent<Rigidbody>();
            if (sphereRigidbody != null)
            {
                sphereRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }

        }

        //Check if the other object is a sphere.
        if (collision.gameObject.CompareTag("sphere"))
        {
            Debug.Log("Cube collided with a Sphere: " + collision.gameObject.name);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Called every frame while colliding.
        // Useful for continuous effects.
    }

    void OnCollisionExit(Collision collision)
    {
        // Called when the collision ends.
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Sphere stopped colliding with cube: " + collision.gameObject.name);

            // Example: Reset the cube's color.
            Renderer cubeRenderer = collision.gameObject.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = Color.white; // Or the original color.
            }
        }
    }
}