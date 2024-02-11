using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Unity.Map;
using Mapbox.Examples;

public class CarMovement : MonoBehaviour
{

    public Transform Target;
    public float Speed;
    public AstronautMouseController Controller;


   

    void Update()
    {

        if (Controller.enabled)// Because the mouse control script interferes with this script
        {
            return;
        }


        var distance = Vector3.Distance(transform.position, Target.position);
        if (distance > 0.1f)
        {
            transform.LookAt(Target.position);
            transform.Translate(Vector3.forward * Speed);
        }
    }
}



