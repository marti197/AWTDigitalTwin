using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Examples;
using Mapbox.Unity.Map;
using UnityEngine.UIElements;


/*
 * This class is created in reference to the AstronautMouseController class from Mapbox.Examples.
 * It provides functionality for controlling a character in a Unity scene, including handling mouse input,
 * managing waypoints, and interacting with the Mapbox SDK.
 * 
  */
public class CarMouseController : MonoBehaviour
{
    [Header("Character")]
    [SerializeField]
    GameObject character;
    [SerializeField]
    float characterSpeed;

    [Header("References")]
    [SerializeField]
    AstronautDirections directions;
    [SerializeField]
    Transform startPoint;
    [SerializeField]
    Transform endPoint;
    [SerializeField]
    AbstractMap map;
    [SerializeField]
    GameObject rayPlane;
    [SerializeField]
    Transform _movementEndPoint;

    [SerializeField]
    LayerMask layerMask;

    [Header("Camera")]
    [SerializeField]
    Camera cam;

    [Header("Settings")]
    [Tooltip("Enables automatic camera follow for the car")]
    public bool camFollowCar;

    Ray ray;
    RaycastHit hit;
    LayerMask raycastPlane;
    float clicktime;
    bool moving;
    bool characterDisabled;

    void Start()
    {

        if (!Application.isEditor)
        {
            this.enabled = false;
            return;
        }
    }

    void Update()
    {
        if (characterDisabled)
            return;
        if (camFollowCar) { CamControl(); }

        bool click = false;

        if (Input.GetMouseButtonDown(0))
        {
            clicktime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - clicktime < 0.15f)
            {
                click = true;
            }
        }

        if (click)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                startPoint.position = transform.localPosition;
                endPoint.position = hit.point;
                MovementEndpointControl(hit.point, true);
                //Mapbox Directions API
                directions.Query(GetPositions, startPoint, endPoint, map);
            }
        }
    }

    List<Vector3> futurePositions;
    bool interruption;
    void GetPositions(List<Vector3> vecs)
    {
        futurePositions = vecs;

        if (futurePositions != null && moving)
        {
            interruption = true;
        }
        if (!moving)
        {
            interruption = false;
            MoveToNextPlace();
        }
    }

    Vector3 nextPos;
    void MoveToNextPlace()
    {
        if (futurePositions.Count > 0)
        {
            nextPos = futurePositions[0];
            futurePositions.Remove(nextPos);

            moving = true;
            StartCoroutine(MoveTo());
        }
        else if (futurePositions.Count <= 0)
        {
            moving = false;
        }
    }

    Vector3 prevPos;
    IEnumerator MoveTo()
    {
        prevPos = transform.localPosition;

        float time = CalculateTime();
        float t = 0;

        StartCoroutine(LookAtNextPos());

        while (t < 1 && !interruption)
        {
            t += Time.deltaTime / time;

            transform.localPosition = Vector3.Lerp(prevPos, nextPos, t);

            yield return null;
        }

        interruption = false;
        MoveToNextPlace();
    }

    float CalculateTime()
    {
        float timeToMove = 0;

        timeToMove = Vector3.Distance(prevPos, nextPos) / characterSpeed;

        return timeToMove;
    }

    IEnumerator LookAtNextPos()
    {
        Quaternion neededRotation = Quaternion.LookRotation(nextPos - character.transform.position);
        Quaternion thisRotation = character.transform.localRotation;

        float t = 0;
        while (t < 1.0f)
        {
            t += Time.deltaTime / 0.25f;
            var rotationValue = Quaternion.Slerp(thisRotation, neededRotation, t);
            character.transform.rotation = Quaternion.Euler(0, rotationValue.eulerAngles.y, 0);
            yield return null;
        }
    }

    Vector3 previousPos = Vector3.zero;
    Vector3 deltaPos = Vector3.zero;

    void CamControl()
    {
        deltaPos = transform.position - previousPos;
        deltaPos.y = 0;
        cam.transform.position = Vector3.Lerp(cam.transform.position, cam.transform.position + deltaPos, Time.time);
        previousPos = transform.position;
    }
    public void DisableCharacter()
    {
        characterDisabled = true;
        moving = false;
        StopAllCoroutines();
        character.SetActive(false);
    }

    public void EnableCharacter()
    {
        characterDisabled = false;
        character.SetActive(true);

        // Distance between astronaut in front of the camera 
        float distanceFromCamera = 30.0f; 

        Quaternion currentCameraRotation = cam.transform.rotation;

        // Calculate the position in front of the camera
        Vector3 newPosition = cam.transform.position;
        newPosition.y = 0;
        newPosition.z += 30;

        character.transform.position = newPosition;

        //cam.transform.LookAt(character.transform);
    }

    void MovementEndpointControl(Vector3 pos, bool active)
    {
        _movementEndPoint.position = new Vector3(pos.x, 0.2f, pos.z);
        _movementEndPoint.gameObject.SetActive(active);
    }
}
