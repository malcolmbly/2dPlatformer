using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("difficultyToggle").GetComponent<Toggle>());
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level #1");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
