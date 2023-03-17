using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;

        public void Init()
        {
            var pCreator = new PlayerCreator();
            pCreator.Init(_world.NewEntity());
        }
    }
}
