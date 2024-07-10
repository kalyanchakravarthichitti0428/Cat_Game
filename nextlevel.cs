using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "endpoint"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the next scene index
            
        }
    }
}
