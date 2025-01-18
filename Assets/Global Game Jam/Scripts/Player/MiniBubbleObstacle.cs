using UnityEngine;

public class MiniBubbleObstacle : MonoBehaviour, IDamage
{
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

    public int OnTakeReward()
    {
        return 0;
    }

    public int OnTakeDamage()
    {
        return 1;
    }
}
