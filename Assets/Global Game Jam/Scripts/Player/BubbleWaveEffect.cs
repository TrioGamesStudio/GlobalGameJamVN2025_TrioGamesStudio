using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWaveEffect : MonoBehaviour
{
    public float waveSpeed = 2f; // Speed of the wave effect
    public float waveOffset = 0.5f; // Offset for the wave effect
    public float floatAmplitude = 0.5f; // Amplitude of the floating motion
    public float followSpeed = 5f; // Speed at which child bubbles follow the player
    public float spacing = 1f; // Spacing between bubbles in the trail

    private List<GameObject> childBubbles; // List of bubbles following the player
    public Action<int> OnChangedBubbleChild;
    void Start()
    {
        childBubbles = new List<GameObject>();
    }

    void Update()
    {
        ApplyWaveEffectToChildBubbles();
    }

    private void ApplyWaveEffectToChildBubbles()
    {
        // Make each bubble in the trail follow the player in a wave-like motion
        for (int i = 0; i < childBubbles.Count; i++)
        {
            if (childBubbles[i] != null)
            {
                // Calculate the target position for this bubble in the trail
                Vector3 targetPosition = transform.position - (i + 1) * spacing * Vector3.right;

                // Add a wave effect based on the player's X-axis position and offset for this bubble
                float waveOffsetY = Mathf.Sin((Time.time + i * waveOffset) * waveSpeed) * floatAmplitude;
                targetPosition.y = transform.position.y + waveOffsetY;

                // Smoothly move the bubble to the target position
                childBubbles[i].transform.position = Vector3.Lerp(childBubbles[i].transform.position, targetPosition, Time.deltaTime * followSpeed);
                //childBubbles[i].GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Check if the colliding object is another bubble
        if (other.gameObject.CompareTag("Bubble") && !childBubbles.Contains(other.gameObject))
        {
            // Add the bubble to the trail
            childBubbles.Add(other.gameObject);
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            
            OnChangedBubbleChild?.Invoke(childBubbles.Count);
        }
    }

    public void DestroyBubbleChildren()
    {
        // Make each bubble in the trail follow the player in a wave-like motion
        for (int i = 0; i < childBubbles.Count; i++)
        {
            Destroy(childBubbles[i]);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Check if the colliding object is another bubble
    //    if (other.CompareTag("Bubble") && !childBubbles.Contains(other.gameObject))
    //    {
    //        // Add the bubble to the trail
    //        childBubbles.Add(other.gameObject);
    //        other.GetComponent<Collider>().isTrigger = true;
    //    }
    //}
}
