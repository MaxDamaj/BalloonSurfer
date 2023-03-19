using BalloonSurfer.Creators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.EntitySources
{
    public class MoveSideEnemySource : EnemySource
    {
        public float sideSpeed;

        public override void SetCreator()
        {
            Creator = new MoveSideEnemyCreator();
        }
    }
}
