using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed of movement in units per second
    public float xDistance = 1.3f; // Total distance to move in the x-axis
    public float yDistance = 1f; // Distance to move in the y-axis
    private bool movingForward = true; // Flag to indicate movement direction
    private Vector3 startPosition; // Starting position of the object

    void Start()
    {
        // Save the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = movingForward ? startPosition + new Vector3(xDistance, yDistance, 0) : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if the object reached the target position
        if (transform.position == targetPosition)
        {
            movingForward = !movingForward; // Change movement direction
        }
    }
}
