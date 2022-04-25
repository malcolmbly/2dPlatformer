using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

/// <summary>
/// Different settings available to the player when they access the setting menu
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    public ToggleGroup difficultyToggle;
    private Toggle easyToggle;
    private Toggle mediumToggle;
    private Toggle hardToggle;
    public Difficulty DifficultySetting { get; set; }

    /// <summary>
    /// Display the main menu with options for the player to choose.
    /// </summary>
    public void LoadMainMenu()
    {
        UpdateDifficulty();
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Change the difficulties of the game with the preset speed value for the enemies.
    /// </summary>
    private void UpdateDifficulty()
    {

        easyToggle = GameObject.Find("easyToggle").GetComponent<Toggle>();
        mediumToggle = GameObject.Find("mediumToggle").GetComponent<Toggle>();
        hardToggle = GameObject.Find("hardToggle").GetComponent<Toggle>();

        if (easyToggle.isOn)
        {
            GameParams.GameDifficulty = Difficulty.Easy;

        } else if (mediumToggle.isOn)
        {
            GameParams.GameDifficulty = Difficulty.Medium;

        } else if (hardToggle.isOn)
        {
            GameParams.GameDifficulty = Difficulty.Hard;
        }

       
    }

}
