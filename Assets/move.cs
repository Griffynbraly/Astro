using UnityEngine;

public class VerticalMover : MonoBehaviour
{
    // Adjustable speed for up and down movement
    public float speed = 2f;

    // Range for the movement (distance from the starting position)
    public float range = 1f;

    // Original position of the object to move relative to it
    private Vector3 startPos;

    void Start()
    {
        // Store the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * range;

        // Update the object's position
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
