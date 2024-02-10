using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficAnimator : MonoBehaviour
{
    //Customizable speed 
    public Material MaterialLowTraffic;
    public float SpeedLowT = 0.5f;
    public Material MaterialModerateTraffic;
    public float SpeedModerateT = 0.2f;
    public Material MaterialHeavyTraffic;
    public float SpeedHeavyT = 0.05f;
    public Material MaterialSevereTraffic;
    public float SpeedSevereT = 0.01f;

    private float _offsetLowTraffic;
    private float _offsetModerateTraffic;
    private float _offsetHeavyTraffic;
    private float _offsetSevereTraffic;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Set Low Traffic 
        MaterialLowTraffic.SetTextureOffset("_MainTex",  new Vector2(_offsetLowTraffic, 0.2f));
        _offsetLowTraffic += Time.deltaTime * SpeedLowT;

        // Set Moderate Traffic
        MaterialModerateTraffic.SetTextureOffset("_MainTex", new Vector2(_offsetModerateTraffic, 0.2f));
        _offsetModerateTraffic += Time.deltaTime * SpeedModerateT;

        // Set Heavy Traffic
        MaterialHeavyTraffic.SetTextureOffset("_MainTex", new Vector2(_offsetHeavyTraffic, 0.2f));
        _offsetHeavyTraffic += Time.deltaTime * SpeedHeavyT;

        // Set Severe Traffic
        MaterialSevereTraffic.SetTextureOffset("_MainTex", new Vector2(_offsetSevereTraffic, 0.2f));
        _offsetSevereTraffic += Time.deltaTime * SpeedSevereT;
    }
}
