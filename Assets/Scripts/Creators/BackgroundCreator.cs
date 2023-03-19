using BalloonSurfer.Components;
using BalloonSurfer.EntitySources;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class BackgroundCreator : EntityCreator
    {
        public override void Init(EntitySource source, EcsEntity entity)
        {
            ref var moveDown = ref entity.Get<MoveDownComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var sprite = ref entity.Get<SpriteComponent>();

            var backgroundPrefab = GameObject.Instantiate(MainData.GetData<BackgroundsInitData>().basePrefab, Vector3.zero, Quaternion.identity);

            movable.speed = MainData.GetData<BackgroundsInitData>().moveSpeed;
            moveDown.Init(backgroundPrefab);
            spawnable.Init(backgroundPrefab, MainData.GetData<BackgroundsInitData>().spawnHeight, MainData.GetData<BackgroundsInitData>().spawnHeight);
            sprite.Init(backgroundPrefab);
        }
    }
}
