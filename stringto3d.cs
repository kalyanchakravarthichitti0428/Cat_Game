using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class stringto3d : MonoBehaviour
{
    public InputField inputField;
    public Transform instantiateTransform;
    public GameObject[] objectsArray;
    public float distance = 1.0f;  
    public float spacingY = 1.0f;
    public int maxLettersPerLine = 10;
    public float rotationDuration = 2.0f;

    private void Start()
    {
        
    }

    private void Spawn()
    {
        string input = "CONGRATULATIONS";

        foreach (Transform child in instantiateTransform)
        {
            Destroy(child.gameObject);
        }

        int totalLetters = input.Length;
        int currentIndex = 0;

        int totalLines = Mathf.CeilToInt((float)totalLetters / maxLettersPerLine);

        while (currentIndex < totalLetters)
        {
            for (int line = 0; line < totalLines && currentIndex < totalLetters; line++)
            {
                int lettersInThisLine = Mathf.Min(maxLettersPerLine, totalLetters - currentIndex);
                float currentX = instantiateTransform.position.x;
                float currentY = instantiateTransform.position.y - line * spacingY;
                float totalWidth = 0f;

                
                for (int i = 0; i < lettersInThisLine; i++)
                {
                    char letter = input[currentIndex + i];
                    if (letter >= 'A' && letter <= 'Z')
                    {
                        int index = letter - 'A';
                        if (index >= 0 && index < objectsArray.Length)
                        {
                            GameObject letterObject = objectsArray[index];
                            MeshFilter meshFilter = letterObject.GetComponent<MeshFilter>();
                            if (meshFilter != null)
                            {
                                float letterWidth = meshFilter.sharedMesh.bounds.size.x * 50 + distance;  
                                totalWidth += letterWidth;
                            }
                        }
                    }
                }

                
                float startX = instantiateTransform.position.x - totalWidth / 2f;
                currentX = startX;

                
                for (int i = 0; i < lettersInThisLine; i++)
                {
                    char letter = input[currentIndex];
                    if (letter >= 'A' && letter <= 'Z')
                    {
                        int index = letter - 'A';
                        if (index >= 0 && index < objectsArray.Length)
                        {
                            GameObject letterObject = objectsArray[index];
                            Vector3 position = new Vector3(currentX, currentY, instantiateTransform.position.z);
                            GameObject instantiatedLetter = Instantiate(letterObject, position, Quaternion.identity, instantiateTransform);
                            instantiatedLetter.transform.localScale = new Vector3(50, 50, 50);

                            MeshFilter meshFilter = instantiatedLetter.GetComponent<MeshFilter>();
                            if (meshFilter != null)
                            {
                                float letterWidth = meshFilter.sharedMesh.bounds.size.x * 50;
                                currentX += letterWidth + distance;  
                            }

                            
                            StartCoroutine(RotateLetter(instantiatedLetter.transform));
                        }
                    }
                    currentIndex++; 
                }
            }
        }
    }

    
    private IEnumerator RotateLetter(Transform letterTransform)
    {
        float minRotation = 150.0f; 
        float maxRotation = 200.0f; 
        while (true)
        {
            if (letterTransform == null) yield break; 
            for (float angle = minRotation; angle <= maxRotation; angle += Time.deltaTime * 100 / rotationDuration)
            {
                if (letterTransform == null) yield break;
                letterTransform.localRotation = Quaternion.Euler(0, angle, 0);
                yield return null;
            }
            for (float angle = maxRotation; angle >= minRotation; angle -= Time.deltaTime * 100 / rotationDuration)
            {
                if (letterTransform == null) yield break;
                letterTransform.localRotation = Quaternion.Euler(0, angle, 0);
                yield return null;
            }
        }
    }
}
