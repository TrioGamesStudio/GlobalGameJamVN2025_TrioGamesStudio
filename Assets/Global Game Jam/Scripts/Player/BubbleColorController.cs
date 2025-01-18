using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleColorController : MonoBehaviour
{
    [Header("Color Change Settings")]
    public Gradient colorGradient; // Gradient to define the bubble's color over time
    public float colorChangeSpeed = 1f; // Speed of the color transition

    private SpriteRenderer spriteRenderer;
    private float colorTime;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing on the bubble object!");
        }

        // Initialize color time
        colorTime = 0f;
    }

    void Update()
    {
        if (spriteRenderer != null)
        {
            // Increment color time based on the speed
            colorTime += Time.deltaTime * colorChangeSpeed;

            // Wrap colorTime to stay within [0, 1] for looping
            colorTime %= 1f;

            // Get the color from the gradient based on colorTime
            Color bubbleColor = colorGradient.Evaluate(colorTime);

            // Apply the color to the SpriteRenderer
            spriteRenderer.color = bubbleColor;
        }
    }
}
