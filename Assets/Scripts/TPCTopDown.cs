using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCTopDown : TPCTrack
{
    public float distanceFromPlayer;

    protected override void OnEnable(){
        camera.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    protected override void LateUpdate(){
        Vector3 targetPos = new Vector3(player.position.x, player.position.y + playerHeight + distanceFromPlayer, player.position.z);
        camera.position = Vector3.Lerp(camera.position, targetPos, Time.deltaTime * damping);
    }
}
