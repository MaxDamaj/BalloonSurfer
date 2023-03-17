using BalloonSurfer.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class PlayerCreator : EntityCreator
    {
        public override void Init(EcsEntity entity)
        {
            ref var moveSideComponent = ref entity.Get<MoveSideComponent>();
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var collDetector = ref entity.Get<ColliderDetectorComponent>();

            var playerPrefab = GameObject.Instantiate(MainData.Instance.playerInitData.prefab, Vector3.zero, Quaternion.identity);
            movableComponent.speed = MainData.Instance.playerInitData.moveSideSpeed;
            moveSideComponent.Init(playerPrefab);
            collDetector.Init(playerPrefab);
        }
    }
}
