using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuManager : MonoBehaviour
{
    // Static means that the value stored in this class member will be shared by all the instances of that class
    public static StartMenuManager Instance;

    public int highScore;
    public string playerName;
    public string currentPlayer;

    // Awake is called as soon as the object the script is attached to is created
    private void Awake()
    {
        // Check if there is a GameManager object (Singleton) make sure only 1 instance can ever exist
        /*
        if (Instance != null)
        {
            Destroy(gameObject);

            // Exit the methode
            return;
        }
        */
        // This reffers to this script, wich is stored in Instance, that is available trough static 
        Instance = this;
        
        // This gameObject is not to e destroyd when the scene changes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        /*
        LoadHighscore();
        Debug.Log("Start :" + highScore);
        Debug.Log("Start: " + playerName);
        */
    }

    // Load scene 1 - called by the Start button
    public void StartMain()
    {
        SceneManager.LoadScene(1);
    }

    // Exit application - called by the Exit button
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
        public string currentPlayer;
    }

    // Save Methode
    public void SaveHighscore()
    {
        // Create a new instance of SaveData + fill the variables
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;
        data.currentPlayer = currentPlayer;

        // Transform the instance to JSON
        string json = JsonUtility.ToJson(data);

        // Write the JSON to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Load Methode
    public void LoadHighscore()
    {
        // The path to the save file
        string path = Application.persistentDataPath + "/savefile.json";

        // Check if file exists
        if (File.Exists(path))
        {
            // Read the file
            string json = File.ReadAllText(path);

            // Transform the file to a SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Set the variables to the variables in SaveData
            highScore = data.highScore;
            playerName = data.playerName;
            currentPlayer = data.currentPlayer;
        }
    }
    
}
