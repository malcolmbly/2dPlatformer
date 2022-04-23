using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject highScoreContainer;
    public GameObject highScoreList;

    public void Awake()
    {
        //get the container to hide/display the high scores
        highScoreContainer.SetActive(false);

        PopulateHighScoreList();

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

    public void ToggleHighScores()
    {
        if (highScoreContainer.activeSelf == true)
        {
            highScoreContainer.SetActive(false);
        }
        else
        {
            highScoreContainer.SetActive(true);
        }
        
    }

    public void PopulateHighScoreList()
    {
        TextMeshProUGUI highScoreListText = highScoreList.GetComponent<TextMeshProUGUI>();
        highScoreListText.SetText("1. MAL - 100\n" + 
            "2. COL - 100\n" +
            "3. QUA - 100");
    }

}
