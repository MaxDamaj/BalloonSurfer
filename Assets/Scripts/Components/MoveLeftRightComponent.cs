using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct MoveLeftRightComponent
    {
        public Transform transform;
        public float speed;

        public float direction { get; private set; }

        public void StartMove()
        {
            direction = speed;
        }

        public void SwitchDirection()
        {
            direction = -direction;
        }
    }
}
