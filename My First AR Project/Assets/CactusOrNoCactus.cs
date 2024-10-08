using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusOrNoCactus : MonoBehaviour
{
    private Animator animator;  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to the cactus
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the object becomes visible to the camera
    void OnBecameVisible()
    {
        gameObject.SetActive(true); // Make the cactus visible
        if (animator != null)
        {
            animator.SetTrigger("TrVisibility"); // Trigger the appearance animation
        }
    }

    // Called when the object is no longer visible to the camera
    void OnBecameInvisible()
    {
        // Optionally, you can reset the trigger or hide the cactus when it's no longer visible
        if (animator != null)
        {
            animator.ResetTrigger("TrVisibility"); // Reset the TrAppear trigger (optional)
        }
        gameObject.SetActive(false); // Hide the cactus when it's out of view
    }
}
