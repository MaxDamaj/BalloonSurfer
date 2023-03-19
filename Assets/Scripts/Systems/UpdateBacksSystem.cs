using BalloonSurfer.Components;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class UpdateBacksSystem : IEcsRunSystem
    {
        private EcsFilter<MovableComponent, MoveDownComponent, SpawnableComponent, SpriteComponent>.Exclude<ColliderComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get2(i);

                if (moveDown.transform.position.y <= MainData.GetData<BackgroundsInitData>().DespawnHeight)
                {
                    UpdatePosition(_filter.GetEntity(i));
                }
            }
        }


        private void UpdatePosition(EcsEntity entity)
        {
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var sprite = ref entity.Get<SpriteComponent>();

            sprite.Init(MainData.GetData<BackgroundsInitData>().NextBackgroundSprite);
            spawnable.SetHeight(MainData.GetData<BackgroundsInitData>().spawnHeight);
        }
    }
}

