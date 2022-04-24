using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject highScoreContainer;
    public GameObject highScoreList;
    public GameObject nameField;

    public void Awake()
    {
        //get the container to hide/display the high scores
        highScoreContainer.SetActive(false);

        PopulateHighScoreList("Assets/TextFile/data.txt");

    }
    public void PlayGame()
    { 
        string name = nameField.GetComponent<TMP_InputField>().text.ToUpper();
        if(name.Length == 0 || name.Equals("ENTER INITIALS"))
        {
            nameField.GetComponent<TMP_InputField>().text = "ENTER INITIALS";
        }
        else
        {
            GameParams.playerName = name.ToUpper();
            SceneManager.LoadScene("Level #3");
        }

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

    public void PopulateHighScoreList(string fileName)
    {


        //example row: {"MAL",90}
        string[] rawScores = File.ReadAllLines(fileName);

        var sortedScores = from line in rawScores
                           let fields = line.Split(',')
                           orderby (int.Parse(fields[1])) descending
                          
                           select line;

        var topTenScores = sortedScores.Take(10);

        TextMeshProUGUI highScoreListText = highScoreList.GetComponent<TextMeshProUGUI>();

        string scoreString = "";
        int position= 0;
        foreach (string score in topTenScores)
        {
            string[] score_fields = score.Split(',');
            string initials = score_fields[0].Substring(1, 3);
            string points = score_fields[1];
            position++;
            scoreString += $"{position}. {initials} - {points}"+ "\n";

        }
        highScoreListText.SetText(scoreString);
    }

}
