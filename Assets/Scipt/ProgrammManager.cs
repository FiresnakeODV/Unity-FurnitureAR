using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;

    private ARRaycastManager ARRaycastManagerScript;
    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn;

    public bool ChooseObject = false;

    [Header("Put ScrollView here")]
    public GameObject ScrollView;

    [SerializeField] private Camera ARCamera;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject SelectedObject;
    public bool Rotation;
    private Quaternion YRotation;
    private AddObject AddObjectScript;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        AddObjectScript = FindObjectOfType<AddObject>();
        PlaneMarkerPrefab.SetActive(false);
        ScrollView.SetActive(false);  
         
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseObject)
        {
            ShowMarkerandSetObject();
        }

        MoveObjectAndRotation();
    }

    void ShowMarkerandSetObject()
    {
    
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        
        //показывает маркер
        if(hits.Count > 0) 
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
        //установка маркера
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false);
            AddObjectScript.UnhideButton(); 
        }
    }

    void MoveObjectAndRotation()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;
            
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("Unselected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }

            SelectedObject = GameObject.FindWithTag("Selected");

            if (touch.phase == TouchPhase.Moved && Input.touchCount == 1)
            {
                if (Rotation)
                {
                    YRotation = Quaternion.Euler(0f, -touch.deltaPosition.x * 0.1f, 0f);
                    SelectedObject.transform.rotation = YRotation * SelectedObject.transform.rotation;

                }
                else
                {
                  ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);
                  SelectedObject.transform.position = hits[0].pose.position;  
                }
                
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "Unselected";
                }
            }

        }

    }

   
}

