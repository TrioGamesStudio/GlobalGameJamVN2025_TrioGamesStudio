using System;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI diamondText;

    
    public void OnHealthUpdate(int health)
    {
        healthText.text = "Health " + health;
    }

    public void OnDiamondUpdate(int diamond) {
        diamondText.text = "Diamond " + diamond;
    }
}
