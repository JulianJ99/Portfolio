using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public GameObject player;


    public static Vector3 lastCheckpointPosition = new Vector3(5, 8, -1293);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < 0) {
            player.transform.position = lastCheckpointPosition;

        }
        if (Input.GetKeyDown("r")) { 
            player.transform.position = lastCheckpointPosition;

        } 
      
    }
}
