using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    protected InputController inputController;

    [Header("Movement Settings")]
    public float speed = 2f; // Speed of movement along the X-axis
    public float floatAmplitude = 0.5f; // Height of the floating motion
    public float floatFrequency = 1f; // Speed of the floating motion
    public float verticalSpeed = 3f; // Vertical speed when pressing W/S keys

    private Vector3 startPosition;
    private Vector2 input;

    private void Awake()
    {
        inputController = new InputController();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    void Start()
    {
        // Store the initial position of the bubble
        startPosition = transform.position;
        AssignInputEvents();
    }

    void Update()
    {
        MoveBubble();
    }

    protected virtual void AssignInputEvents()
    {
        inputController.Player.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
        inputController.Player.Move.canceled += ctx => input = Vector2.zero;
    }

    private void MoveBubble()
    {
        // Move the bubble along the X-axis
        transform.position += speed * Time.deltaTime * Vector3.right;

        // Add vertical movement when pressing W/S keys
        if (Mathf.Abs(input.y) > 0.1f)
        {
            // Adjust vertical position based on input
            float verticalInput = input.y * verticalSpeed * Time.deltaTime;
            transform.position += new Vector3(0, verticalInput, 0);

            // Update the startPosition.y to the current height to ensure floating starts from here
            startPosition.y = Mathf.Lerp(startPosition.y, transform.position.y, 0.1f); // Smoothly adjust start height
        }
        else
        {
            // Apply floating motion with a smooth transition to the natural position
            float targetY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            float smoothedY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * 5f); // Smoothly transition to floating
            transform.position = new Vector3(transform.position.x, smoothedY, transform.position.z);
        }
    }
}
