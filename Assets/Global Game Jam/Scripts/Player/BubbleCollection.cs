using System;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollection : MonoBehaviour
{
    BubbleData bubbleData;

    private void Awake() {
        bubbleData = GetComponent<BubbleData>();
    }

    private void OnTriggerEnter(Collider other) {
        IReward rewardPickup = other.GetComponent<IReward>();
        IDamage stoneObstacle = other.GetComponent<IDamage>();
        

        if(rewardPickup != null) {
            if(rewardPickup as HealthPickup)
                bubbleData.OnTakeHealth(rewardPickup.OnTakeReward());

            if(rewardPickup as DiamondPickup)
                bubbleData.OnTakeDiamond(rewardPickup.OnTakeDiamond());
        }

        if(stoneObstacle != null) {
            bubbleData.OnTakeDamage(stoneObstacle.OnTakeDamage());
        }

    }

    // generate bubble
    /* if(rewardPickup as MiniBubbleObstacle) {
            MiniBubbleController newMiniBubble = rewardPickup.OnGenerateMiniBubble();
            if(miniBubbleList.Count < 1) {
                miniBubbleList.Add(newMiniBubble);
                MiniBubbleController newMini = Instantiate(miniBubbleList[0], transform.position, Quaternion.identity, bubbleParent);
                Debug.Log($"_____co chay vao day");
            }
        } */

}
