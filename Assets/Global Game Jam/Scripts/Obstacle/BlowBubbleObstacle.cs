using UnityEngine;

public class BlowBubbleObstacle : MonoBehaviour
{
    [SerializeField] MiniBubbleObstacle miniBubbleObstacle;

    [Header("Bubble Generation Settings")]
    [SerializeField] float spawnInterval = 2f;  // Time between bubble spawns
    [SerializeField] float bubbleSpeed = 5f;    // Speed of the bubble
    [SerializeField] float minAngle = 45f;       // Minimum angle in degrees
    [SerializeField] float maxAngle = 135f;      // Maximum angle in degrees
    
    private float nextSpawnTime;

    [SerializeField] Transform spawnMiniBubble;
    AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }
    
    private void Update()
    {
        // Check if it's time to generate a new bubble
        if (Time.time >= nextSpawnTime)
        {
            GenerateBubble();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    
    void GenerateBubble()
    {
        if (miniBubbleObstacle == null) return;
        
        // Create new bubble instance
        MiniBubbleObstacle newBubble = Instantiate(miniBubbleObstacle, spawnMiniBubble.position, Quaternion.identity);
        audioSource.Play();
        // Generate random angle between minAngle and maxAngle
        float randomAngle = Random.Range(minAngle, maxAngle);
        
        // Convert angle to radians and calculate direction
        float angleRad = randomAngle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        
        // Set bubble velocity
        if (newBubble.GetComponent<Rigidbody>() != null)
        {
            newBubble.GetComponent<Rigidbody>().velocity = direction * bubbleSpeed;
        }
    }
}
