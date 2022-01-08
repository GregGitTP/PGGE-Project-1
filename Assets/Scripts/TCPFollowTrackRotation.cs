using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCPFollowTrackRotation : TPCFollow
{
    protected override void OnEnable(){
        base.OnEnable();
    }

    protected override void Update(){
        camera.position = Vector3.Lerp(camera.position, player.TransformPoint(new Vector3(x, y, z)), Time.deltaTime * damping);

        camera.LookAt(new Vector3(player.position.x, player.position.y + playerHeight, player.position.z));
    }
}
