using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            PlayerDie.lastCheckpointPosition = transform.position;
            Debug.Log("CheckPoint");
        }
    }
}
