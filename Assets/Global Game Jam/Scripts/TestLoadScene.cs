using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLoadScene : MonoBehaviour
{
    public static TestLoadScene Instance;
    public static string LEVEL_SCENE = "Gameplay_";
    public static string MENU_SCENE = "Start";
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
