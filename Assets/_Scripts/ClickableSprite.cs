using UnityEngine;

// This script detects when the player clicks on a sprite
public class ClickableSprite : MonoBehaviour
{
    // This function is automatically called when the mouse clicks on this object
    void OnMouseDown()
    {
        // Code here runs when the sprite is clicked
        Debug.Log("Sprite was clicked!");
        
        // Example: Change the sprite's color when clicked
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    // Optional: Detect when mouse button is released
    void OnMouseUp()
    {
        Debug.Log("Mouse button released!");
        
        // Example: Change color back to white
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    // Optional: Detect when mouse hovers over the sprite
    void OnMouseEnter()
    {
        Debug.Log("Mouse is hovering over sprite!");
    }
    
    // Optional: Detect when mouse stops hovering
    void OnMouseExit()
    {
        Debug.Log("Mouse left the sprite!");
    }
}