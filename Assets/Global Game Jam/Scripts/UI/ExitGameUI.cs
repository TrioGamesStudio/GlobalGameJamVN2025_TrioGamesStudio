using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameUI : MonoBehaviour
{
    public GameObject PopUpButton;

    public Button YesButton;
    public Button NoButton;
    private void Awake()
    {
        PopUpButton.gameObject.SetActive(false);
        YesButton.onClick.AddListener(OnYes);
        NoButton.onClick.AddListener(OnNo);
    }

    private void OnDestroy()
    {
        YesButton.onClick.RemoveListener(OnYes);
        NoButton.onClick.RemoveListener(OnNo);
    }

    private void OnYes()
    {
        Time.timeScale = 1;
        TestLoadScene.Instance.Load(TestLoadScene.MENU_SCENE);
    }

    private void OnNo()
    {
        Hide();
    }
    [Button]
    public void Show()
    {
        PopUpButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    [Button]
    public void Hide()
    {
        PopUpButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}