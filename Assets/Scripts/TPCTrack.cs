using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCTrack : TPCBase
{
    protected override void OnEnable(){
        camera.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    protected override void Update(){
        camera.LookAt(new Vector3(player.position.x, player.position.y + playerHeight, player.position.z));
    }
}
