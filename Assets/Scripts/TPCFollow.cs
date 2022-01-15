using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;

public class TPCFollow : TPCBase
{
    protected float x, y, z;

    public TPCFollow(Transform _camera, Transform _player, float _x, float _y, float _z) : base(_camera, _player){
        x = _x;
        y = _y;
        z = _z;
    }

    protected override void Start(){
        camera.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    protected override void Update(){
        camera.position = Vector3.Lerp(camera.position, player.position + new Vector3(x, y, z), Time.deltaTime * damping);
    }
}
