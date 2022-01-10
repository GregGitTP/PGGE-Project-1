using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstacles : MonoBehaviour
{
    public Transform camera, player;
    public float playerHeight;

    private void Update(){
        Vector3 offset = player.forward;
        
        Vector3 cameraPosition = GetComponent<TPCFollowTrackRotation>().camPos - offset;

        Vector3 playerPosition = new Vector3(player.position.x, player.position.y + playerHeight, player.position.z);

        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit hit;

        if(Physics.Raycast(cameraPosition, (playerPosition - cameraPosition), out hit, Vector3.Distance(cameraPosition, playerPosition), mask)){
            GetComponent<TPCFollowTrackRotation>().blocked = true;
            GetComponent<TPCFollowTrackRotation>().blockedCamPos = hit.point + (offset * 1.5f);
        }
        else{
            GetComponent<TPCFollowTrackRotation>().blocked = false;
        }
    }
}
