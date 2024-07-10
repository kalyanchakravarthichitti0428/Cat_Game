using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 correctPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        CheckPlacement();
    }

    private void CheckPlacement()
    {
        // Check if the object is placed in the correct position
        float distance = Vector3.Distance(transform.position, correctPosition);
        if (distance > 1.0f) // Adjust this threshold as needed
        {
            // If placed incorrectly, go to retry scene
            SceneManager.LoadScene("retry");
        }
    }
}
