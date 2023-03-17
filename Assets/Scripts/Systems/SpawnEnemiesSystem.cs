using BalloonSurfer.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class SpawnEnemiesSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<MoveDownComponent, SpawnableComponent> _filter = null;

        private float _spawnTime = 0;

        public void Init()
        {
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
                var enemyData = MainData.Instance.enemiesInitData.GetRandomEnemy();

                var enemy = _world.NewEntity();
                ref var moveDown = ref enemy.Get<MoveDownComponent>();
                ref var movable = ref enemy.Get<MovableComponent>();
                ref var spawnable = ref enemy.Get<SpawnableComponent>();
                ref var collider = ref enemy.Get<ColliderComponent>();

                var enemyPrefab = GameObject.Instantiate(MainData.Instance.enemiesInitData.baseEnemyPrefab);

                moveDown.Init(enemyPrefab, enemyData);
                moveDown.Spawn(MainData.Instance.fieldInitData.RandomLine);

                spawnable.id = enemyData.enemyName;
                movable.speed = enemyData.moveDownSpeed;
                collider.Init(enemyPrefab, enemyData);
            }
        }
    }
}
