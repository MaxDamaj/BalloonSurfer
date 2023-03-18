using BalloonSurfer.Components;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class UpdateBacksSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<MovableComponent, MoveDownComponent, SpawnableComponent, SpriteComponent> _filter = null;

        public void Init()
        {
            _filter.ExcludedTypes = new System.Type[] { typeof(ColliderComponent) };
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get2(i);

                if (moveDown.transform.position.y <= MainData.Instance.backgroundsInitData.DespawnHeight)
                {
                    UpdatePosition(_filter.GetEntity(i));
                }
            }
        }


        private void UpdatePosition(EcsEntity entity)
        {
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var sprite = ref entity.Get<SpriteComponent>();

            sprite.Init(MainData.Instance.backgroundsInitData.NextBackgroundSprite);
            spawnable.SetHeight(MainData.Instance.backgroundsInitData.spawnHeight);
        }
    }
}

