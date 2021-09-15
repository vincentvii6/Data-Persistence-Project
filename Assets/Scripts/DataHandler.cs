using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;

    public string Name = "";
    public string CurrentName;
    public int Bestscore = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
    }

    [System.Serializable]
    class HighScores
    {
        public string Name = "";
        public int Bestscore = 0;
    }

    public void SaveHighScores()
    {
        HighScores data = new HighScores();
        data.Name = Name;
        data.Bestscore = Bestscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscores.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/highscores.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScores data = JsonUtility.FromJson<HighScores>(json);

            Name = data.Name;
            Bestscore = data.Bestscore;
        }
    }
}
