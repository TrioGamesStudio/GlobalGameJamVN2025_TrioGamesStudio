using UnityEngine;

public class MiniBubbleObstacle : MonoBehaviour, IDamage
{
    int healtReduce = 1;
    [SerializeField] MiniBubbleController miniBubbleController;
    [SerializeField] float timeToDestroy = 1;
    AudioSource audioSource;
    [SerializeField] GameObject explosion;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            audioSource.Play();
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            Destroy(this.gameObject, 0.1f);

        }
    }

    public int OnTakeDamage()
    {
        return healtReduce;
    }
}
