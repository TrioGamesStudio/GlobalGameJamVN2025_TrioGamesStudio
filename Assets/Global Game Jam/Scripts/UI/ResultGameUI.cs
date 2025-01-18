using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameUI : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Image shineGlowImg;
    public float rotateZValue;
    public float rotateSpeed = 5;
    public float lerpingValue = 5;
  
    private void Update()
    {
        rotateZValue += Time.deltaTime * rotateSpeed;
        if (rotateZValue > 360 )
            rotateZValue = 0;
        Quaternion nextQuater = 
            Quaternion.Euler(
                shineGlowImg.transform.localRotation.x, 
                shineGlowImg.transform.localRotation.y, 
                rotateZValue);

        Quaternion lerping =
            Quaternion.Lerp(shineGlowImg.transform.localRotation, nextQuater, Time.deltaTime * lerpingValue);
        shineGlowImg.transform.localRotation = lerping;
    }

    public void Complete()
    {
        resultText.text = "Complete Level "+DataManager.currentMapLevelData.level;
        LoadGameResult();
    }

    public void Loose()
    {
        resultText.text = "Failed";
        LoadGameResult();
    }

    public TextMeshProUGUI bubbleCollectText;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI timeCompleteText;

    private void LoadGameResult()
    {
        bubbleCollectText.text = $"{DataManager.TotalBubbleCollected} / {DataManager.currentMapLevelData.maxBubble}" ;
        diamondText.text = $"{DataManager.TotalDiamondCollected} / {DataManager.currentMapLevelData.maxDiamond}" ;
        timeCompleteText.text = ClockUI.FormatTime(DataManager.TotalTime);
    }
}