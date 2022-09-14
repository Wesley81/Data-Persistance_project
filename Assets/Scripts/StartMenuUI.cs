using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    public InputField nameInputField;
    public static string playerName;

    // Start is called before the first frame update
    public void Start()
    {
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
        playerName = nameInputField.text;
        Debug.Log(playerName);
    }
}
