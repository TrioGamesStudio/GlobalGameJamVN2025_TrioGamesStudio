using UnityEngine;

public class HealthManagerUI : MonoBehaviour
{
    public HealthUI[] healths;
    public HealthUI prefab;
    public GameObject container;
    public void Init(int count)
    {
        healths = new HealthUI[count];

        for (int i = 0; i < count; i++)
        {
            healths[i] = Instantiate(prefab, container.transform);
        }
    }
    public void OnChangedHealth(int currentHealth)
    {
        for (int i = 0; i < healths.Length; i++)
        {
            bool isActive = i < currentHealth;
            healths[i].Toggle(isActive);
        }
    }
}