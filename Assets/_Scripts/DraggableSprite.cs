using UnityEngine;

// This script makes a sprite draggable with the mouse
// Attach this to your sprite GameObject
public class DraggableSprite : MonoBehaviour
{
    // Reference to the main camera
    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the main camera in the scene
        mainCamera = Camera.main;
    }
    
    // OnMouseDrag is called every frame while the mouse is dragging the object
    void OnMouseDrag()
    {
        // Get the current mouse position in screen coordinates (pixels)
        Vector3 mousePosition = Input.mousePosition;
        
        // Set the z-position to match the camera's distance from the sprite
        // This ensures the sprite stays at the correct depth
        mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        
        // Convert the screen position to world position
        // This transforms pixel coordinates into Unity world coordinates
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        
        // Update the sprite's position to follow the mouse
        transform.position = worldPosition;
    }
}