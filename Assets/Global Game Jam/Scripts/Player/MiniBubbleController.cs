using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBubbleController : MonoBehaviour
{
    BubbleController bubbleController;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 lastBubblePosition;
    
    [Header("Floating Settings")]
    public float floatFrequency = 1f;    // Speed of the floating motion
    public float floatAmplitude = 0.5f;  // Height of the floating motion
    
    [Header("Following Settings")]
    public float followSpeed = 5f;        // Speed to follow the main bubble
    public float followOffset = 2f;       // Distance to maintain from main bubble
    public float moveThreshold = 0.01f;   // Threshold to determine if main bubble is moving

    void Start()
    {
        bubbleController = FindObjectOfType<BubbleController>();
        if (bubbleController != null)
        {
            // Set initial positions
            startPosition = bubbleController.transform.position + new Vector3(-followOffset, 0, 0);
            lastBubblePosition = bubbleController.transform.position;
            transform.position = startPosition;
        }
    }

    void Update()
    {
        if (bubbleController == null) return;

        // Check if the main bubble is moving
        float bubbleMovement = Vector3.Distance(bubbleController.transform.position, lastBubblePosition);
        bool isMainBubbleMoving = bubbleMovement > moveThreshold;

        if (isMainBubbleMoving)
        {
            // Follow the main bubble with offset
            targetPosition = bubbleController.transform.position + new Vector3(-followOffset, 0, 0);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        }
        else
        {
            // Apply floating motion when stationary
            float floatingY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            Vector3 floatingPosition = new Vector3(transform.position.x, floatingY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, floatingPosition, Time.deltaTime * followSpeed);
        }

        // Update last known position of the main bubble
        lastBubblePosition = bubbleController.transform.position;
        
        // Update start position based on current x position to maintain proper floating center
        startPosition = new Vector3(transform.position.x, bubbleController.transform.position.y, transform.position.z);
    }
}
