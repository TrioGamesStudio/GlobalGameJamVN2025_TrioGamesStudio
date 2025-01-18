using TMPro;
using UnityEngine;

public class BubbleUI : MonoBehaviour
{
    public TextMeshProUGUI bubbleText;

    private void Awake()
    {
        OnChangedBubble(0);
    }

    public void OnChangedBubble(int bubble)
    {
        bubbleText.text = bubble.ToString();
    }
}