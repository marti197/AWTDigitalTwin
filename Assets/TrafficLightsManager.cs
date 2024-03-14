using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsManager : MonoBehaviour
{
     // Die GameObjects, die die Ampeln darstellen
    public GameObject redLight;
    public GameObject greenLight;
    


    // Die Materialien, die die Ampelfarben darstellen
    public Material redGlow;
    public Material greenGlow;
    public Material offGlow;

    // Die Dauer jeder Ampelphase in Sekunden
    public float redTime = 10f;
    public float greenTime = 10f;

    // Die aktuelle Ampelfarbe
    private string currentColor = "red";

    // Die Zeit, die seit dem letzten Farbwechsel vergangen ist
    private float timer = 0f;

    // Die Methode, die beim Start des Skripts aufgerufen wird
    private void Start()
    {
        // Die Anfangsfarbe auf Rot setzen
        SetColor("red");
    }

    // Die Methode, die jedes Frame aufgerufen wird
    private void Update()
    {
        // Die Zeit erhöhen
        timer += Time.deltaTime;

        // Die Farbe wechseln, wenn die Zeit abgelaufen ist
        switch (currentColor)
        {
            case "red":
                if (timer >= redTime)
                {
                    SetColor("green");
                }
                break;
            case "green":
                if (timer >= greenTime)
                {
                    SetColor("red");
                }
                break;
        }
    }

    // Die Methode, die die Ampelfarbe ändert
    private void SetColor(string color)
    {
        // Die aktuelle Farbe und die Zeit zurücksetzen
        currentColor = color;
        timer = 0f;

        // Die Materialien entsprechend der Farbe zuweisen
        switch (color)
        {
            case "red":
                redLight.GetComponent<Renderer>().material = redGlow;
                greenLight.GetComponent<Renderer>().material = offGlow;
                break;
            case "green":
                redLight.GetComponent<Renderer>().material = offGlow;
                greenLight.GetComponent<Renderer>().material = greenGlow;
                break;
        }
    }
}
