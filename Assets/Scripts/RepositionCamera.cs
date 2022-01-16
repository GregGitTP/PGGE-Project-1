using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;

public class RepositionCamera
{
    Transform camera, player;
    TPCFollowTrackRotation tpc;

    public RepositionCamera(Transform _camera, Transform _player, TPCFollowTrackRotation _tpc){
        camera = _camera;
        player = _player;
        tpc = _tpc;
    }

    public void Update(){
        Vector3 offset = player.forward;
        
        Vector3 cameraPosition = tpc.camPos - offset;

        Vector3 playerPosition = new Vector3(player.position.x, player.position.y + GameConstants.playerHeight, player.position.z);

        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit hit;

        if(Physics.Raycast(playerPosition, (cameraPosition - playerPosition), out hit, Vector3.Distance(cameraPosition, playerPosition), mask)){
            tpc.blocked = true;
            tpc.blockedCamPos = hit.point + (offset * 1f);
        }
        else{
            tpc.blocked = false;
        }
    }
}
