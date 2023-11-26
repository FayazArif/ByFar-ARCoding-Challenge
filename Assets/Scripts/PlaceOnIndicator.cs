using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnIndicator : MonoBehaviour
{
    [SerializeField]
    GameObject placementIndication;
    
    GameObject spawnedObject;

    public bool markerstatus = false;
    public bool modelStatus = false;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    DownloadAssetBundle downloadasset;

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        placementIndication.SetActive(false);

    }

    private void Start()
    {
        downloadasset = GetComponent<DownloadAssetBundle>();
    }

    private void Update()
    {
        if(aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            var hitpose = hits[0].pose;
            placementIndication.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
            placementIndication.SetActive(true);

            if (!placementIndication.activeInHierarchy && markerstatus)
            {
                placementIndication.SetActive(true);
            }
            else if(placementIndication.activeInHierarchy && !markerstatus)
            {
                placementIndication.SetActive(false);
            }
        }
    }

    public void EnableDisablePlacedMarker()
    {
        if (!markerstatus)
        {
            markerstatus = true;
        }
        else
            markerstatus = false;
    }

    public void PlacedObject()
    {
        if (!placementIndication.activeInHierarchy)
            return;

        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(downloadasset.InstantiateGameObjFromServer(), placementIndication.transform.position, placementIndication.transform.rotation);
        }
        else
        {
            spawnedObject.transform.SetPositionAndRotation(placementIndication.transform.position, placementIndication.transform.rotation);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

}
