using TMPro;
using UnityEngine;

public class DiamondUI : MonoBehaviour
{
    public TextMeshProUGUI diamondText;

    private void Awake()
    {
        diamondText.text = "0";
    }

    public void OnChangedDiamond(int count)
    {
        diamondText.text = count.ToString();
    }
}