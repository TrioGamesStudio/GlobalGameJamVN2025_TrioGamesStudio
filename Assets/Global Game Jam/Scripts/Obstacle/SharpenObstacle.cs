using UnityEngine;

public class SharpenObstacle : MonoBehaviour, IDamage
{
    int healtReduce = 1;

    AudioSource audioSource;
    [SerializeField] GameObject explosion;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            audioSource.Play();
        }
    }
    public int OnTakeDamage()
    {
        return healtReduce;
    }
}
