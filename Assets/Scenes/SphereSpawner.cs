using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // Reference to the sphere prefab to be spawned
    public float spawnHeight = 1.0f; // Height above the ground to spawn the sphere

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Check if the ray hits something in the scene
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Get the hit point on the ground
                Vector3 spawnPosition = hitInfo.point;
                spawnPosition.y += spawnHeight; // Adjust the height

                // Spawn a sphere at the adjusted position
                SpawnSphere(spawnPosition);
            }
        }
    }

    // Function to spawn a sphere at a given position
    void SpawnSphere(Vector3 position)
    {
        Instantiate(spherePrefab, position, Quaternion.identity);
    }
}

