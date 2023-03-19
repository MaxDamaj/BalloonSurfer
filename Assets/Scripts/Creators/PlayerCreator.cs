using BalloonSurfer.Components;
using BalloonSurfer.EntitySources;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class PlayerCreator : EntityCreator
    {
        public override void Init(EntitySource source, EcsEntity entity)
        {
            ref var moveSideComponent = ref entity.Get<MoveSideComponent>();
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var collDetector = ref entity.Get<ColliderDetectorComponent>();

            var playerPrefab = GameObject.Instantiate(MainData.GetData<PlayerInitData>().prefab, Vector3.zero, Quaternion.identity);
            movableComponent.speed = MainData.GetData<PlayerInitData>().moveSideSpeed;
            moveSideComponent.Init(playerPrefab);
            collDetector.Init(playerPrefab);
        }
    }
}
