using UnityEngine;

public class RotateClockwise : MonoBehaviour
{
    public float rotationSpeed = -50f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object clockwise around its center
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
