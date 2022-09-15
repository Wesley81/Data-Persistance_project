using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenuUI : MonoBehaviour
{
    public InputField nameInputField;
    
    public string playerName;
    public int highScore;
    public string currentPlayer;
    public TMP_Text highscoreText;

    // Start is called before the first frame update
    public void Start()
    {
        StartMenuManager.Instance.LoadHighscore();
        playerName = StartMenuManager.Instance.playerName;
        Debug.Log("Menu: " + StartMenuManager.Instance.playerName);
        highScore = StartMenuManager.Instance.highScore;
        Debug.Log("Menu: "+ StartMenuManager.Instance.highScore);
        currentPlayer = StartMenuManager.Instance.currentPlayer;

        highscoreText.text = "Best Score : " + playerName + " : " + highScore;

        // Check if value on InputField changed
        nameInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // What to do when value on InputField changed
    public void ValueChangeCheck()
    {
        // Set the inputfield text to playerName
        currentPlayer = nameInputField.text;
        // Debug.Log(playerName);
        StartMenuManager.Instance.playerName = playerName;
        StartMenuManager.Instance.highScore = highScore;
        StartMenuManager.Instance.currentPlayer = currentPlayer;
        StartMenuManager.Instance.SaveHighscore();
    }
}
