using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARSessionOrigin sessionOrigin;
    private float ghostValue;

    // List<ARRaycastHit> hits;
    
    [SerializeField] GameObject PrefabToPlace; 
    [SerializeField] ARPlaneManager aRPlaneManager; 
    [SerializeField, Range(1f, 100f)] float ghostRate = 1f, ghostChance = 10f;
    public static int ghostRemaining = 5;
    // Start is called before the first frame update
    void Awake()
    {
        sessionOrigin = GetComponent<ARSessionOrigin>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRPlaneManager.planesChanged += planeChanged;
    }

    private void planeChanged(ARPlanesChangedEventArgs args){
        if(args.added != null){
            ghostValue = Random.Range(0, ghostChance);

            ARPlane aRPlane = args.added[0];
            if(ghostValue <= ghostRate && ghostRemaining > 0){
                PrefabToPlace = Instantiate(PrefabToPlace, aRPlane.transform.position, Quaternion.identity);
                ghostRemaining -= 1;
            }
        }
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began){
                if(sessionOrigin.GetComponent<ARRaycastManager>().Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon) 
                && ghostRemaining > 0){
                    Pose pose = hits[0].pose;
                    Instantiate(PrefabToPlace, pose.position, pose.rotation);
                    ghostRemaining--;
                    textGhostRemaining.text = "Ghost Remaining: " + ghostRemaining.ToString();
                }
            }
        }
    }
    */
}
