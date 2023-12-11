using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation ;
using UnityEngine.XR.ARSubsystems;

public class plantManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] flowers;
    public ARSessionOrigin sessionOrigin;
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private void update() {

        if(Input.GetTouch(0).phase == TouchPhase.Began){
           bool collision= raycastManager.Raycast(Input.mousePosition,raycastHits,TrackableType.PlaneWithinPolygon);

            if(collision){
                GameObject _object=Instantiate(flowers[Random.Range(0,flowers.Length-1)]);
                _object.transform.position=raycastHits[0].pose.position;

            }

            foreach(var plane in planeManager.trackables){
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled=false;
        }
    }
}
