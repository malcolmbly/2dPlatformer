

using UnityEngine;

using UnityEditor;

using System.IO;

public class WriteToFile : MonoBehaviour
{

    private static string time = System.DateTime.UtcNow.ToLocalTime().ToString("HH: mm");


    private bool written = false;

    [MenuItem("Tools/Write file")]

    private void Update()
    {
        if (PlayerMovement.won && !written)
        {
            WriteString();
            written = true;
        }
    }


    private static void WriteString()
    {

        string path = "Assets/TextFile/data.txt";

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine($"Your Score: {PlayerMovement.points}, Time of Day: {time}");

        writer.Close();

        //Re-import the file to update the reference in the editor

        //AssetDatabase.ImportAsset(path);

        //TextAsset asset = (TextAsset)Resources.Load("data");

        //Print the text from the file

        //Debug.Log(asset.text);

    }

    private static void ReadString()
    {
        string path = "Assets/TextFile/data.txt";

        //Read the text from directly from the test.txt file

        StreamReader reader = new StreamReader(path);

        Debug.Log(reader.ReadToEnd());

        reader.Close();

    }

}


