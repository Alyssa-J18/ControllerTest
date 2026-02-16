using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements

// This script adds a click listener to a button using code
public class ButtonClickCode : MonoBehaviour
{
    // Reference to the button we want to add a click event to
    // Drag your button into this field in the Inspector
    public Button myButton;
    
    // Start is called before the first frame update
    void Start()
    {
        // Check if the button reference exists (safety check)
        if (myButton != null)
        {
            // Add a listener that calls OnButtonClick when the button is clicked
            // AddListener connects a function to the button's click event
            myButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            // If no button is assigned, show an error message
            Debug.LogError("Button is not assigned in the Inspector!");
        }
    }
    
    // This function is called when the button is clicked
    void OnButtonClick()
    {
        // Code here runs when the button is clicked
        Debug.Log("Button clicked via code!");
        

    }
    
    // Optional: Remove the listener when this object is destroyed
    // This prevents errors if the button is destroyed
    void OnDestroy()
    {
        // Check if button exists before trying to remove listener
        if (myButton != null)
        {
            // Remove the listener to clean up
            myButton.onClick.RemoveListener(OnButtonClick);
        }
    }
}