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

    void Start()
    {
        animatorController = GetComponent<AnimatorController>();
        FaceMovingDirection();
    }

    void Update()
    {
        animatorController.SetInt("animation,14");
        // Move the bird left along the X-axis
        transform.Translate(speed * Time.deltaTime * Vector3.right);
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
            Destroy(gameObject, 0.1f);

        }
    }
}
