using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class SpawnBacksSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world = null;
        private BackgroundCreator _backgroundCreator;

        private EcsFilter<MovableComponent, MoveDownComponent, SpawnableComponent, SpriteComponent>.Exclude<ColliderComponent> _filter = null;

        public void Destroy()
        {
            SharedData.Instance.currentBackIndex = -1;
        }

        public void Init()
        {
            SharedData.Instance.currentBackIndex = -1;
            _backgroundCreator = new BackgroundCreator();

            SpawnFirst();
            Spawn();
        }


        private void SpawnFirst()
        {
            Spawn();
            ref var spawnable = ref _filter.Get3(0);
            spawnable.SetHeight(MainData.GetData<BackgroundsInitData>().firstSpawnHeight);
        }

        private void Spawn()
        {
            var entity = _world.NewEntity();
            _backgroundCreator.Init(null, entity);

            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var sprite = ref entity.Get<SpriteComponent>();

            sprite.Init(MainData.GetData<BackgroundsInitData>().NextBackgroundSprite);
            spawnable.Spawn(0);
        }
    }
}
