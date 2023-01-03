using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] float ZoomedOutFOV = 60f;
    [SerializeField] float ZoomedInFOV = 40f;
    [SerializeField] float ZoomOutSensitivity = 2f;
    [SerializeField] float ZoomInSensitivity = 1f;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;

    private void OnDisable(){
        ZoomOut();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            if(zoomedInToggle == false){
                ZoomIn();
            }
            else{
                ZoomOut();
        }
        }

    }

    private void ZoomIn(){
            zoomedInToggle = true;
            fpsCamera.fieldOfView = ZoomedInFOV;
            fpsController.mouseLook.XSensitivity = ZoomInSensitivity;
            fpsController.mouseLook.YSensitivity = ZoomInSensitivity;
    }

    private void ZoomOut(){
            zoomedInToggle = false;
            fpsCamera.fieldOfView = ZoomedOutFOV;
            fpsController.mouseLook.XSensitivity = ZoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = ZoomOutSensitivity;
    }
}
