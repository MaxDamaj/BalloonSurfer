using BalloonSurfer.Components;
using BalloonSurfer.Helpers;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class EnemyCreator : EntityCreator
    {
        public override void Init(EcsEntity entity)
        {
            var enemyData = MainData.Instance.enemiesInitData.GetRandomEnemy();

            ref var moveDown = ref entity.Get<MoveDownComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var collider = ref entity.Get<ColliderComponent>();

            var enemyPrefab = GameObject.Instantiate(MainData.Instance.enemiesInitData.baseEnemyPrefab);

            moveDown.Init(enemyPrefab, enemyData);
            moveDown.Spawn(MainData.Instance.fieldInitData.RandomLine);

            spawnable.id = enemyData.enemyName;
            movable.speed = enemyData.moveDownSpeed;
            collider.Init(enemyPrefab, enemyData);
        }

        public void Mutate(EcsEntity entity)
        {
            ref var collider = ref entity.Get<ColliderComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var movable = ref entity.Get<MovableComponent>();

            var enemyData = MainData.Instance.enemiesInitData.GetRandomEnemy();
            if (spawnable.id != enemyData.enemyName)
            {
                collider.Mutate(enemyData);
                spawnable.id = enemyData.enemyName;
                movable.speed = enemyData.moveDownSpeed;
            }
        }
    }
}
