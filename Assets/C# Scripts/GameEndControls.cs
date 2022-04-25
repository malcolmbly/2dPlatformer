using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Display the main menu screen with the options for the players to input name,
/// change difficulties, exit and start game. 
/// </summary>
public class GameEndControls : MonoBehaviour
{
    /// <summary>
    /// Load the menu and display all the options for the players. 
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
