using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private PortalPair portalPair;

    [SerializeField]
    private Image inPortalImg;

    [SerializeField]
    private Image outPortalImg;

    public Transform player;

    private void Start()
    {
        var portals = portalPair.Portals;

        inPortalImg.color = portals[0].PortalColour;
        outPortalImg.color = portals[1].PortalColour;

        inPortalImg.gameObject.SetActive(false);
        outPortalImg.gameObject.SetActive(false);
    }

    private void Update(){
        if(player.transform.position.y < 0.1){
            inPortalImg.gameObject.SetActive(false);
            outPortalImg.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown("r")){
            inPortalImg.gameObject.SetActive(false);
            outPortalImg.gameObject.SetActive(false);
        }
    }

    public void SetPortalPlaced(int portalID, bool isPlaced)
    {
        if(portalID == 0)
        {
            inPortalImg.gameObject.SetActive(isPlaced);
        }
        else
        {
            outPortalImg.gameObject.SetActive(isPlaced);
        }
    }
}
