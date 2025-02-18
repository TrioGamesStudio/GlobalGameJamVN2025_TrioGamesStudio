using System;
using UnityEngine;

public class BubbleData : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int diamond = 0;
    public Action<int> UpdateHealthAction_UIhandler;
    public Action<int> UpdateDiamondAction_UIhandler;
    [SerializeField] GameObject explosion;
    public Action<bool> OnShowResultTable;
    public bool isFinish = false;
    private void Start() {
        health = 3;
        UpdateHealthAction_UIhandler?.Invoke(health);

        diamond = 0;
        UpdateDiamondAction_UIhandler?.Invoke(diamond);
    }

    public void OnTakeDamage(int damage) {
        health -= damage;

        // run Action to update UI health
        UpdateHealthAction_UIhandler?.Invoke(health);

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            GetComponent<BubbleWaveEffect>().DestroyBubbleChildren();
            Destroy(gameObject, 0.5f);
            OnShowResultTable?.Invoke(false);
        }
    }

    public void OnTakeHealth(int reward)
    {
        if (health >= 3)
            return;
        health += reward;

        // run Action to update UI health
        UpdateHealthAction_UIhandler?.Invoke(health);
    }

    public void OnTakeDiamond(int diamondReward) {
        diamond += diamondReward;
        UpdateDiamondAction_UIhandler?.Invoke(diamond);
    }

    public int GetDiamond()
    {
        return diamond;
    }
}
