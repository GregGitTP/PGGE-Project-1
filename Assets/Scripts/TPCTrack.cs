using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;

public class TPCTrack : TPCBase
{
    public TPCTrack(Transform _camera, Transform _player) : base(_camera, _player){}

    protected override void Start(){
        camera.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    protected override void Update(){
        camera.LookAt(new Vector3(player.position.x, player.position.y + playerHeight, player.position.z));
    }
}
