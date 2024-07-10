using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private int currentSceneIndex;
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 offset;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Set the Rigidbody to kinematic initially
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        

        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            isDragging = true;
                            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector3 cursorPosition = new Vector3(touch.position.x, touch.position.y, 0);
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(cursorPosition) + offset;
                        rb.MovePosition(newPosition);
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    rb.velocity = Vector3.zero; // Stop the player's movement when dragging ends
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") )
        {
            Handheld.Vibrate();
            SceneManager.LoadScene("retry");
        }
        else if (other.CompareTag("Endpoint") )
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    private void OnMouseDown()
    {
        if (!isDragging)
        {
            rb.isKinematic = false; // Disable kinematic to allow physics to move the player
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
    }

    private void OnMouseUp()
    {
        rb.isKinematic = true; // Re-enable kinematic to stop physics interactions
    }
}
