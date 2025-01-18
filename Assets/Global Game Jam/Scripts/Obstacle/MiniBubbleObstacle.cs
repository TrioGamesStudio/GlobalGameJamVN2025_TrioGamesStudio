using UnityEngine;

public class MiniBubbleObstacle : MonoBehaviour, IDamage
{
    int healtReduce = 1;
    [SerializeField] MiniBubbleController miniBubbleController;
    [SerializeField] float timeToDestroy = 1;
    
    private void Start() {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            Destroy(this.gameObject, 0.1f);

        }
    }

    public int OnTakeDamage()
    {
        return healtReduce;
    }
}
