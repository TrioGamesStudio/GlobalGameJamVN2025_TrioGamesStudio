
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    protected InputController inputController;
    private Vector2 input;
    private Vector2 inputScale;

    [Header("Movement Settings")]
    public float speed = 2f; // Speed of movement along the X-axis
    public float floatAmplitude = 0.5f; // Height of the floating motion
    public float floatFrequency = 1f; // Speed of the floating motion
    public float verticalSpeed = 3f; // Vertical speed when pressing W/S keys
    private Vector3 startPosition;
    
    [Header("Scale Settings")]
    public float scaleSpeed = 3f; // Speed at which the bubble scales
    public float maxScale = 4f; // Maximum scale factor
    public float minScale = 1f; // Minimum scale factor
    private Vector3 targetScale; // Target scale for smooth scaling
    private bool isScaleUp = false;
    private bool isScaleDown = false;
    [Header("Speed Scale")] 
    [SerializeField] private float speedScaleUp = .8f;
    [SerializeField] private float speedScaleDown = 1.4f;

    private Vector3 currentScale;
    private BubbleData bubbleData;
    private void Awake()
    {
        inputController = new InputController();
        bubbleData = GetComponent<BubbleData>();
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
        AssignInputEvents();

        // Store the initial position of the bubble
        startPosition = transform.position;

        // Initialize the target scale to the current scale
        targetScale = transform.localScale;
    }

    public float offsetY;
    void Update()
    {
        if (bubbleData.isFinish) return;
        
        MoveBubble();
        ScaleBubble();
        distance = transform.localScale.x * .5f + offsetY;
        // Debug.DrawLine(transform.position,transform.position + Vector3.up * distance , Color.red);
    }

    private void AssignInputEvents()
    {
        inputController.Player.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
        inputController.Player.Move.canceled += ctx => input = Vector2.zero;
        inputController.Player.ScaleUp.started += _ => { isScaleUp = true; };
        inputController.Player.ScaleUp.canceled += _ => { isScaleUp = false; };
        inputController.Player.ScaleDown.started += _ => { isScaleDown = true; };
        inputController.Player.ScaleDown.canceled += _ => { isScaleDown = false; };
    }

    /// <summary>
    /// Handles the bubble's movement along the X-axis and vertical movement based on input.
    /// </summary>
    private void MoveBubble()
    {
        // Move the bubble along the X-axis
        transform.position += (speed * speedScale) * Time.deltaTime * Vector3.right;
        if (IsCellFloor() && input.y > 0.1f)
            return;
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

    public LayerMask cellingMask;
    public float distance = .1f;
    private bool IsCellFloor()
    {
        return Physics.Raycast(transform.position, Vector3.up, distance , cellingMask);
    }

    private void ScaleBubble()
    {
        if (isScaleUp) ScaleUp();
        if (isScaleDown) ScaleDown();
        // Smoothly interpolate towards the target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        currentScale = transform.localScale;
    }

    private void LimitSpeedScale()
    {
        if (currentScale.x is > 1 and < 3)
        {
            speedScale = 1;
        }
    }

    public float speedScale = 0;
    /// <summary>
    /// Scales the bubble up, increasing its size.
    /// </summary>
    public void ScaleUp()
    {
        // Increase the target scale while clamping to the maxScale
        if (currentScale.x > 3f)
        {
            speedScale = speedScaleUp;
        }

        // LimitSpeedScale();
        targetScale += Vector3.one * 0.1f;
        targetScale = Vector3.Min(targetScale, Vector3.one * maxScale);
    }
    
    /// <summary>
    /// Scales the bubble down, decreasing its size.
    /// </summary>
    public void ScaleDown()
    {
        // Decrease the target scale while clamping to the minScale
        if (currentScale.x < 2f)
        {
            speedScale = speedScaleDown;
        }
        // LimitSpeedScale();
        targetScale -= Vector3.one * 0.1f;
        targetScale = Vector3.Max(targetScale, Vector3.one * minScale);
    }

}
