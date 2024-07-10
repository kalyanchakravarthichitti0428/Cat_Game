using UnityEngine;

public class RotateBetweenAngles : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second
    private float targetRotation = 40f; // Target rotation angle
    private float currentRotation = 0f; // Current rotation angle
    private int rotationDirection = 1; // Rotation direction (1 for clockwise, -1 for counter-clockwise)

    void Update()
    {
        // Calculate the new rotation angle
        currentRotation += rotationSpeed * Time.deltaTime * rotationDirection;

        // Check if the target rotation angle is reached
        if (Mathf.Abs(currentRotation) >= Mathf.Abs(targetRotation))
        {
            // Reverse the rotation direction
            rotationDirection *= -1;
        }

        // Apply the rotation
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
