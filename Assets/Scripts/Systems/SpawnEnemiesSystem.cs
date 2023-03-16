using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class SpawnEnemiesSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<MoveDownComponent, SpawnableComponent> _filter = null;

        private float _spawnTime = 0;

        public void Run()
        {
            if (_spawnTime > 0)
            {
                _spawnTime -= Time.deltaTime;
            }

            if (_spawnTime <= 0)
            {
                SpawnEnemy();
                _spawnTime = 4;
            }
        }


        private void SpawnEnemy()
        {
            if (_filter.GetEntitiesCount() < 8)
            {
                var score = SharedData.Instance.scoreValue;
                var enemiesData = MainData.Instance.enemiesInitData.enemies.FindAll(x => x.minSpawnScore <= score && x.maxSpawnScore >= score);

                if (enemiesData.Count > 0)
                {
                    int randomIndex = Random.Range(0, enemiesData.Count);
                    var enemyData = enemiesData[randomIndex];

                    var enemy = _world.NewEntity();
                    ref var moveDown = ref enemy.Get<MoveDownComponent>();
                    ref var movable = ref enemy.Get<MovableComponent>();
                    enemy.Get<SpawnableComponent>();

                    moveDown.transform = GameObject.Instantiate(enemyData.prefab).transform;
                    moveDown.transform.position = new Vector3(
                        Random.Range(-30f, 30f),
                        Random.Range(MainData.Instance.enemiesInitData.minSpawnHeight, MainData.Instance.enemiesInitData.maxSpawnHeight),
                        0
                    );

                    moveDown.maxSpawnScore = enemyData.maxSpawnScore;
                    moveDown.minSpawnScore = enemyData.minSpawnScore;
                    movable.speed = enemyData.moveDownSpeed;
                }
            }
        }
    }
}
