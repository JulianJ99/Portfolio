using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalStaff : MonoBehaviour
{
    public GameObject PortalCanvas;
    public AudioClip ItemClip;
    public AudioSource PlayerSource;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Behaviour bhvr = (Behaviour)other.GetComponent("PortalPlacement");
            bhvr.enabled = true;
            PortalCanvas.SetActive(true);
            Destroy(gameObject);
            PlayerSource.pitch = 1f;
            PlayerSource.PlayOneShot(ItemClip);
        }
    }
}
