using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class TestMousClick : MonoBehaviour
{
    private InputAction rightClickAction;
    public Text consoleText;
    private string log;
  

    private void OnEnable()
    {
       
        Application.logMessageReceived += LogMessage;
    }

    private void OnDisable()
    {
       
        Application.logMessageReceived -= LogMessage;
    }

  
    void LogMessage(string message, string stackTrace, LogType type)
    {
        log = message + "\n" + log;
        consoleText.text = log;
    }
}
