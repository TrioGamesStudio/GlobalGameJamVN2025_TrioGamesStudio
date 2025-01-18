using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ToggleSoundButtonUI : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite toggleSprite;
    public Button button;
    public UnityEvent toggleEvent;
    private bool temp = false;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Toggle);
    }

    private void Toggle()
    {
        temp = !temp;
    }
}
