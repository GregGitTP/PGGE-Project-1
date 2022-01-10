using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE{
    public abstract class TPCBase : MonoBehaviour
    {
        [SerializeField] protected Transform camera, player;
        [SerializeField] protected float damping, playerHeight;

        protected abstract void OnEnable();
        protected abstract void LateUpdate();
    }
}
