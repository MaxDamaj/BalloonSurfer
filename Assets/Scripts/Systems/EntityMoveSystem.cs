using BalloonSurfer.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class EntityMoveSystem : IEcsRunSystem
    {
        EcsFilter<MoveDownComponent, MovableComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get1(i);
                ref var movable = ref _filter.Get2(i);
                moveDown.transform.position += new Vector3(0, -movable.speed, 0);
            }
        }
    }
}
