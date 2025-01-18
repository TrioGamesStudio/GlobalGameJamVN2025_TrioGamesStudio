using System;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Awake() {
        //OnHealthUpdate(3);
    }
    
    public void OnHealthUpdate(int health)
    {
        textMeshProUGUI.text = "Health " + health;
    }
}
