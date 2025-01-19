
using UnityEngine;

public class DiamondPickup : MonoBehaviour, IReward
{
    [SerializeField] int diamondAmount = 1;
    AudioSource audioSource;
    [SerializeField] GameObject explosion;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        Quaternion rotation = Quaternion.Euler(0, 90 * Time.deltaTime, 0);
            transform.rotation *= rotation;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            audioSource.Play();
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            Destroy(this.gameObject, 0.1f);

        }
    }
    private void OnDisable() {
        
    }

    public int OnTakeDiamond()
    {
        return diamondAmount;
    }
    public int OnTakeReward()
    {
        return 0;
    }
    public MiniBubbleController OnGenerateMiniBubble()
    {
        return null;
    }




}
