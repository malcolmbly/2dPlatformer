using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

/// <summary>
/// The first screen of the game with different options for the player to choose.
/// </summary>
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
    
    /// <summary>
    /// Start the first level of the game.
    /// </summary>
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

    /// <summary>
    /// Navigate to the setting window for all the options that's available to the player.
    /// </summary>
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    /// <summary>
    /// Quit the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Show the highest score of the past players and their name.
    /// If the player played the game, their score is be included
    /// on the leaderboard.
    /// </summary>
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

    /// <summary>
    /// Fill a textfile with highscores and player names. 
    /// </summary>
    /// <param name="fileName">File to be filled with information.</param>
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
