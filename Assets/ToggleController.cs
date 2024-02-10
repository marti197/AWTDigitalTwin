using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;

public class ToggleSettingsController : MonoBehaviour
{
    public Toggle toggleLiveTraffic;
    public Toggle toggleCarMode;
    public Text statusTextLiveTraffic;
    public Text statsuTextCarMode;
    public GameObject carObject;
    public AbstractMap Map;


    private Color _activeColor = Color.green;
    private Color _inactiveColor = Color.red;
    private bool _enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial to false
        //OnToggleValueChanged(false);
        toggleLiveTraffic.onValueChanged.AddListener(OnToggleLiveTrafficValueChanged);
        toggleCarMode.onValueChanged.AddListener(OnToggleCarModeValueChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnToggleLiveTrafficValueChanged(bool isOn)
    {
        _enabled = isOn;
        Map.UpdateMapFeatures();
        statusTextLiveTraffic.text = isOn ? "Live Traffic On" : "Live Traffic Off";
        statusTextLiveTraffic.color = isOn ? _activeColor : _inactiveColor;
    }
    void OnToggleCarModeValueChanged(bool isOn)
    {
        statsuTextCarMode.text = isOn ? "Car Mode On" : "Car Mode Off";
        statsuTextCarMode.color = isOn ? _activeColor : _inactiveColor;

        if (carObject != null)
        {
            carObject.SetActive(isOn);
        }
        else
        {
            Debug.LogError("Error: Car Object is not assigned in the Unity Editor.");
        }
    }

    public bool IsEnabled
    {
        get
        {
            return _enabled;
        }
    }
}
