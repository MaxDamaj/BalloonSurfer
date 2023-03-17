using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public abstract class EntityCreator
    {
        public abstract void Init(EcsEntity entity);
    }
}
