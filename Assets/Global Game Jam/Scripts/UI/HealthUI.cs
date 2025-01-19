using LitMotion;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image activeHealth;
    public Image grayHeath;
    
    public void Toggle(bool isActive)
    {
        if (isActive)
        {
            Active();
        }
        else
        {
            DeActive();
        }
    }
    [Button]
    private void Active()
    {
        activeHealth.gameObject.SetActive(true);
        grayHeath.gameObject.SetActive(false);
    }
    [Button]
    private void DeActive()
    {
        activeHealth.gameObject.SetActive(false);
        grayHeath.gameObject.SetActive(true);
    }
}