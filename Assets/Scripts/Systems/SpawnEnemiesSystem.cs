using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class SpawnEnemiesSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<MovableComponent, MoveDownComponent, SpawnableComponent, ColliderComponent> _filter = null;

        private float _spawnTime = 0;

        public void Init()
        {
            _spawnTime = MainData.GetData<FieldInitData>().spawnDelayTime;
        }

        public void Run()
        {
            if (_spawnTime > 0)
            {
                _spawnTime -= Time.deltaTime;
            }

            if (_spawnTime <= 0)
            {
                SpawnEnemy();
                _spawnTime = MainData.GetData<EnemiesInitData>().enemiesSpawnDelay;
            }
        }


        private void SpawnEnemy()
        {
            if (_filter.GetEntitiesCount() < MainData.GetData<EnemiesInitData>().maxEnemiesOnField)
            {
                var enemy = MainData.GetData<EnemiesInitData>().GetRandomEnemy();
                enemy.Creator.Init(enemy, _world.NewEntity());
            }
        }
    }
}
