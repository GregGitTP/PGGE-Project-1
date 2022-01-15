using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE{
    public abstract class TPCBase
    {
        protected Transform camera, player;

        public TPCBase(Transform _camera, Transform _player){
            camer = _camera;
            player = _player;
        }

        protected abstract void Start();
        protected abstract void Update();
    }
}
