using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickup : MonoBehaviour, IReward
{
    [SerializeField] int diamondAmount = 1;

    private void Update() {
        Quaternion rotation = Quaternion.Euler(0, 90 * Time.deltaTime, 0);
            transform.rotation *= rotation;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BubbleCollection>()) {
            Destroy(this.gameObject, 0.1f);
        }
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
