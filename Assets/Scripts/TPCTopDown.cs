using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCTopDown : TPCTrack
{
    protected float distanceFromPlayer;

    public TPCTopDown(Transform _camera, Transform _player, float _distanceFromPlayer) : base(_camera, _player){
        distanceFromPlayer =  _distanceFromPlayer;
    }

    protected override void Start(){
        camera.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    protected override void Update(){
        Vector3 targetPos = new Vector3(player.position.x, player.position.y + playerHeight + distanceFromPlayer, player.position.z);
        camera.position = Vector3.Lerp(camera.position, targetPos, Time.deltaTime * damping);
    }
}
