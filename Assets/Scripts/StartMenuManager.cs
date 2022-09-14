using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuManager : MonoBehaviour
{
    // Static means that the value stored in this class member will be shared by all the instances of that class
    public static StartMenuManager Instance;

    // Awake is called as soon as the object the script is attached to is created
    private void Awake()
    {
        // Check if there is a GameManager object (Singleton) make sure only 1 instance can ever exist
        if (Instance != null)
        {
            Destroy(gameObject);

            // Exit the methode
            return;
        }

        // This reffers to this script, wich is stored in Instance, that is available trough static 
        Instance = this;

        // This gameObject is not to e destroyd when the scene changes
        DontDestroyOnLoad(gameObject);
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
    
}
