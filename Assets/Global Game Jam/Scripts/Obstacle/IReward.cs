using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReward
{
    public int OnTakeReward();
    public MiniBubbleController OnGenerateMiniBubble();
}
