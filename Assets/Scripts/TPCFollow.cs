using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE;

public class TPCFollow : TPCBase
{
    public float x, y, z;

    protected override void OnEnable(){
        camera.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    protected override void LateUpdate(){
        camera.position = Vector3.Lerp(camera.position, player.position + new Vector3(x, y, z), Time.deltaTime * damping);
    }
}
