using System;
using UnityEngine;

public class BubbleData : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int diamont = 0;
    public Action<int> UpdateHealthAction_UIhandler;
    //others

    private void Start() {
        health = 3;
        UpdateHealthAction_UIhandler?.Invoke(health);
    }

    public void OnTakeDamage(int damage) {
        health -= damage;

        // run Action to update UI health
        UpdateHealthAction_UIhandler?.Invoke(health);
    }

    public void OnTakeReward(int reward) {
        health += reward;

        // run Action to update UI health
        UpdateHealthAction_UIhandler?.Invoke(health);
    }
}
