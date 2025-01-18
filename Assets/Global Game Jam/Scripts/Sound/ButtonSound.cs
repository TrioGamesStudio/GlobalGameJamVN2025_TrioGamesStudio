using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private SoundData soundData;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        soundData?.PlayTest();
    }
}