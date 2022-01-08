using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstacles : MonoBehaviour
{
    public Transform camera, player;

    private void Update(){
        RaycastHit hit;
        Physics.Raycast(camera.position, player.positio, out hit);
    }
}
