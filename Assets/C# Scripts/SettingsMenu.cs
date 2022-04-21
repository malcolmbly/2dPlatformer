using System.Collections;
using System.Collections.Generic;
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
    public Difficulty DifficultySetting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        Difficulty difficultySetting = this.DifficultySetting();
        DontDestroyOnLoad(difficultySetting);
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateDifficulty()
    {
        switch (difficultyToggle) 
        {
            case Difficulty.Easy:
                DifficultySetting = Difficulty.Easy;
                break;
            case Difficulty.Medium:
                DifficultySetting = Difficulty.Easy;
                break;
            case Difficulty.Hard:
                DifficultySetting = Difficulty.Easy;
                break;


        }
            
    }

}
