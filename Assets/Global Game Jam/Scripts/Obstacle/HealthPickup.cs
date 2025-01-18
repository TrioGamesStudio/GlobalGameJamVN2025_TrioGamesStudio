using UnityEngine;

public class HealthPickup : MonoBehaviour, IReward
{
    int healtReward = 1;

    private void Update() {
        Quaternion rotation = Quaternion.Euler(0, 90 * Time.deltaTime, 0);
            transform.rotation *= rotation;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            Destroy(this.gameObject, 0.1f);
        }
    }

    public int OnTakeReward()
    {
        return healtReward;
    }

    public MiniBubbleController OnGenerateMiniBubble()
    {
        return null;
    }

    public int OnTakeDiamond()
    {
        return 0;
    }
}
