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
        resultText.text = "Complete";
    }

    public void Loose()
    {
        resultText.text = "Failed";
    }
}
