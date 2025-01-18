using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Suriyun;

public class Bird : MonoBehaviour, IDamage
{
    [Header("Bird Movement Settings")]
    public float speed = 3f; // Speed of the bird
    private AnimatorController animatorController;
    private int healtReduce = 1;
    AudioSource audioSource;
    [SerializeField] GameObject explosion;
    public float surviveTime = 4f; // Time to survive before turning back
    private bool isTurningBack = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        animatorController = GetComponent<AnimatorController>();
        FaceMovingDirection();
        // Schedule the bird to turn back
        Invoke(nameof(TurnBack), surviveTime);
    }

    void Update()
    {
        //animatorController.SetInt("animation,14");
        //// Move the bird left along the X-axis
        //transform.Translate(speed * Time.deltaTime * Vector3.right);

        if (!isTurningBack)
        {
            animatorController.SetInt("animation,14"); // Replace with your "fly" animation state
            // Move the bird left along the X-axis
            transform.Translate(speed * Time.deltaTime * Vector3.right);
        }
        else
        {
            // Bird moving back in the opposite direction
            transform.Translate(speed / 2 * Time.deltaTime * Vector3.left);
        }
    }

    void FaceMovingDirection()
    {
        // Rotate the bird to face left
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public int OnTakeDamage()
    {
        return healtReduce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BubbleCollection>())
        {
            audioSource.Play();
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            Destroy(gameObject, 0.1f);
        }
    }

    void TurnBack()
    {
        isTurningBack = true;

        // Play the "bye" animation
        animatorController.SetInt("animation,3");

        // Rotate the bird to face the new direction
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
