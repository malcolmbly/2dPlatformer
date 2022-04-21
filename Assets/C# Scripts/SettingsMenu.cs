using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
public class SettingsMenu : MonoBehaviour
{
    public ToggleGroup difficultyToggle;
    private Toggle easyToggle;
    private Toggle mediumToggle;
    private Toggle hardToggle;
    public Difficulty DifficultySetting { get; set; }


    public void LoadMainMenu()
    {
        UpdateDifficulty();
        SceneManager.LoadScene(2);
    }

    private void UpdateDifficulty()
    {
        difficultyToggle = GetComponent<ToggleGroup>();
        Toggle activeDifficultyToggle = difficultyToggle.GetFirstActiveToggle();

        easyToggle = GetComponent<Toggle>();
        mediumToggle = GetComponent<Toggle>();
        hardToggle = GetComponent<Toggle>();

        if (easyToggle.IsActive())
        {
            GameParams.GameDifficulty = Difficulty.Easy;

        } else if (mediumToggle.IsActive())
        {
            GameParams.GameDifficulty = Difficulty.Medium;

        } else if (hardToggle.IsActive())
        {
            GameParams.GameDifficulty = Difficulty.Hard;
        }

       
    }

}
