using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct MoveSideComponent
    {
        public Transform transform;
        public int currentLinePosition;
        public float remainingMoveTime;

        public void Init(GameObject prefab)
        {
            transform = prefab.transform;
            currentLinePosition = 0;
            remainingMoveTime = 0;
        }
    }
}
