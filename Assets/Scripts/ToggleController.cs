using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle toggle;
    public Text statusText;
    private Color _activeColor = Color.green;
    private Color _inactiveColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnToggleValueChanged(bool isOn)
    {
        
        statusText.text = isOn ? "Live Traffic On" : "Live Traffic Off";

        // Ändern Sie die Farbe des Texts basierend auf dem Toggle-Zustand
        statusText.color = isOn ? _activeColor : _inactiveColor;
    }
}
