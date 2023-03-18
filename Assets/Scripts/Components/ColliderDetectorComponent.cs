using BalloonSurfer.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct ColliderDetectorComponent
    {
        public CollisionDetector collisionDetector;

        public void Init(GameObject prefab)
        {
            collisionDetector = prefab.GetComponent<CollisionDetector>();
        }
    }
}
