using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameParams
{
    //TODO As more game options/parameters are added, add them here to be set by the difficulty setting.
    public static Difficulty GameDifficulty { get; set; } = Difficulty.Medium;

    private static Dictionary<Difficulty, int> PlayerHPDict = new Dictionary<Difficulty, int>{ 
        { Difficulty.Easy, 7 }, 
        { Difficulty.Medium, 3 }, 
        { Difficulty.Hard, 1 } 
    };

    private static Dictionary<Difficulty, int> EnemySpeedDict = new Dictionary<Difficulty, int>{
        { Difficulty.Easy, 2 },
        { Difficulty.Medium, 5 },
        { Difficulty.Hard, 10 }
    };

    private static Dictionary<Difficulty, int> PlayerSpeedDict = new Dictionary<Difficulty, int>{
        { Difficulty.Easy, 5 },
        { Difficulty.Medium, 10 },
        { Difficulty.Hard, 25 }
    };

    private static Dictionary<Difficulty, int> EnemySizeDict = new Dictionary<Difficulty, int>{
        { Difficulty.Easy, 5 },
        { Difficulty.Medium, 10 },
        { Difficulty.Hard, 15 }
    };

    public static int GetEnemySpeed()
    {
        return EnemySpeedDict[GameDifficulty];
    }

    public static int GetPlayerHP()
    {
        return PlayerHPDict[GameDifficulty];
    }

    public static int GetPlayerSpeed()
    {
        return PlayerSpeedDict[GameDifficulty];
    }


    public static int GetEnemySize()
    {
        return EnemySizeDict[GameDifficulty];
    }

}
