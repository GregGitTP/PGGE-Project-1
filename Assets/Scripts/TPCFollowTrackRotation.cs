using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCFollowTrackRotation : TPCFollow
{
    public float cameraAngleOffset = 20f;   

    [HideInInspector] public Vector3 camPos, blockedCamPos;
    [HideInInspector] public bool blocked = false;

    protected override void OnEnable(){
        camera.rotation = Quaternion.Euler(cameraAngleOffset, 0f, 0f);
    }

    protected override void LateUpdate(){
        camPos = player.TransformPoint(new Vector3(x, y, z));
        if(!blocked){
            camera.position = Vector3.Lerp(camera.position, camPos, Time.deltaTime * damping);
        }else{
            camera.position = Vector3.Lerp(camera.position, blockedCamPos, Time.deltaTime * damping);
        }

        Vector3 playerAngle = new Vector3(cameraAngleOffset, player.eulerAngles.y, player.eulerAngles.z);

        camera.rotation = Quaternion.Slerp(camera.rotation, Quaternion.Euler(playerAngle), Time.deltaTime * damping);
    }
}
