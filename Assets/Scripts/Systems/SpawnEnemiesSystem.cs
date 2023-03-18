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
        private EnemyCreator _enemyCreator;

        private float _spawnTime = 0;

        public void Init()
        {
            _enemyCreator = new EnemyCreator();
            _spawnTime = MainData.Instance.fieldInitData.spawnDelayTime;
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
                _spawnTime = MainData.Instance.enemiesInitData.enemiesSpawnDelay;
            }
        }


        private void SpawnEnemy()
        {
            if (_filter.GetEntitiesCount() < MainData.Instance.enemiesInitData.maxEnemiesOnField)
            {
                _enemyCreator.Init(_world.NewEntity());
            }
        }
    }
}
