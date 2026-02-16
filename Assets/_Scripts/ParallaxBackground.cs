using UnityEngine;

// This script creates an endless scrolling background effect
// Attach it to a parent GameObject that has child objects with background sprites
public class ParallaxBackground : MonoBehaviour
{
    // Speed at which the background scrolls (units per second)
    // Higher values = faster scrolling
    public float scrollSpeed = 2f;
    
    // Stores the width of one background sprite
    // Used to know when to reposition sprites
    private float spriteWidth;
    
    // Array to hold references to all background sprite GameObjects
    private GameObject[] backgrounds;
    
    // Start is called once before the first frame update
    void Start()
    {
        // Create an array with size equal to the number of child objects
        // transform.childCount tells us how many children this GameObject has
        backgrounds = new GameObject[transform.childCount];
        
        // Loop through each child and store it in our array
        for (int i = 0; i < transform.childCount; i++)
        {
            // GetChild(i) gets the child at index i
            // .gameObject gets the GameObject component
            backgrounds[i] = transform.GetChild(i).gameObject;
        }
        
        // Check if we have at least one background sprite
        if (backgrounds.Length > 0)
        {
            // Get the SpriteRenderer component from the first child
            // This component contains information about the sprite's size
            SpriteRenderer spriteRenderer = backgrounds[0].GetComponent<SpriteRenderer>();
            
            // Check if the SpriteRenderer was found (safety check)
            if (spriteRenderer != null)
            {
                // Get the width of the sprite in world units
                // bounds.size.x gives us the width including any scaling
                spriteWidth = spriteRenderer.bounds.size.x;
            }
            else
            {
                // If no SpriteRenderer is found, show an error message in the console
                Debug.LogError("No SpriteRenderer found on child background objects!");
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // Loop through each background sprite in our array
        foreach (GameObject bg in backgrounds)
        {
            // Move the background to the left
            // Vector3.left is the same as (-1, 0, 0)
            // scrollSpeed controls how fast it moves
            // Time.deltaTime ensures smooth movement regardless of frame rate
            // (Time.deltaTime is the time in seconds since the last frame)
            bg.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
            
            // Check if this background sprite has moved off the left side of the screen
            // We check if its x position is less than negative spriteWidth
            if (bg.transform.position.x < -spriteWidth)
            {
                // Create a new position variable to modify
                Vector3 newPos = bg.transform.position;
                
                // Move the sprite to the right side by adding:
                // spriteWidth * number of backgrounds
                // This places it after all the other background sprites
                newPos.x += spriteWidth * backgrounds.Length;
                
                // Apply the new position to the background sprite
                bg.transform.position = newPos;
            }
        }
    }
}