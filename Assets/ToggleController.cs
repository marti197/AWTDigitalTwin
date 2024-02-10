using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;

public class ToggleSettingsController : MonoBehaviour
{
    public Toggle toggle;
    public Text statusText;
    public AbstractMap Map;


    private Color _activeColor = Color.green;
    private Color _inactiveColor = Color.red;
    private bool _enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial to false
        //OnToggleValueChanged(false);
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnToggleValueChanged(bool isOn)
    {
        _enabled = isOn;
        Map.UpdateMapFeatures();
        statusText.text = isOn ? "Live Traffic On" : "Live Traffic Off";


        statusText.color = isOn ? _activeColor : _inactiveColor;
    }

    public bool IsEnabled
    {
        get
        {
            return _enabled;
        }
    }
}
