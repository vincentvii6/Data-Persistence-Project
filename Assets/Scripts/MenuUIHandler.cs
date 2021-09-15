using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField Name;
    public static string playerName;
    public static int Bestscore;
    public Text text;

    void Start()
    {
        if (Name != null)
        {
            Name.text = playerName;
        }
        
        DataHandler.Instance.LoadHighScores();
        text.text = "Best Score: " + DataHandler.Instance.Name + " : " + DataHandler.Instance.Bestscore;
    }

    public void SaveUsername()
    {
        DataHandler.Instance.CurrentName = Name.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
