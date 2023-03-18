using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct MoveDownComponent
    {
        public Transform transform;

        public void Init(GameObject prefab)
        {
            transform = prefab.transform;
        }

    }
}
