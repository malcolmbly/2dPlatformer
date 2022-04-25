

using UnityEngine;

using UnityEditor;

using System.IO;

/// <summary>
/// Write all the data to the file.
/// </summary
/// <author>Collin Williams</author>
public class WriteToFile : MonoBehaviour
{

    private static string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH: mm");


    private bool written = false;


    private void Update()
    {
        if (PlayerMovement.won && !written)
        {
            WriteString();
            written = true;
        }
    }


    /// <summary>
    /// Write the data of the highscore into the highscore file.
    /// </summary>
    private static void WriteString()
    {

        string path = "Assets/TextFile/data.txt";

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine($"\"{GameParams.playerName}\",{PlayerMovement.points}");

        writer.Close();

        //Re-import the file to update the reference in the editor

        //AssetDatabase.ImportAsset(path);

        //TextAsset asset = (TextAsset)Resources.Load("data");

        //Print the text from the file

        //Debug.Log(asset.text);

    }

    /// <summary>
    /// Read the data from the highscore file and display in the game.
    /// </summary>
    private static void ReadString()
    {
        string path = "Assets/TextFile/data.txt";

        //Read the text from directly from the test.txt file

        StreamReader reader = new StreamReader(path);

        Debug.Log(reader.ReadToEnd());

        reader.Close();

    }

}


