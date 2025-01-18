using UnityEngine;

public class StoneObstacle : MonoBehaviour, IDamage
{
    int healtReduce = 1;

    /* private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            Destroy(this.gameObject, 0.1f);
        }
    } */

    public int OnTakeDamage()
    {
        return healtReduce;
    }
}
