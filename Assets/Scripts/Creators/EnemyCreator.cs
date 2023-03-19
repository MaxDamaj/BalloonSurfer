using BalloonSurfer.Components;
using BalloonSurfer.EntitySources;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class EnemyCreator : MutableCreator
    {
        public override void Init(EntitySource source, EcsEntity entity)
        {
            var enemyData = source as EnemySource;

            ref var moveDown = ref entity.Get<MoveDownComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var collider = ref entity.Get<ColliderComponent>();
            ref var mutate = ref entity.Get<MutateComponent>();

            var enemyPrefab = GameObject.Instantiate(MainData.Instance.enemiesInitData.baseEnemyPrefab);

            moveDown.Init(enemyPrefab);
            spawnable.Init(enemyPrefab, MainData.Instance.enemiesInitData.minSpawnHeight, MainData.Instance.enemiesInitData.maxSpawnHeight, true);
            collider.Init(enemyPrefab, enemyData);
            mutate.Init(enemyData.minSpawnScore, enemyData.maxSpawnScore);

            spawnable.id = enemyData.name;
            movable.speed = enemyData.moveDownSpeed;

            spawnable.Spawn(MainData.Instance.fieldInitData.RandomLine);
        }

        public override void Mutate(MutableSource source, EcsEntity entity)
        {
            var enemyData = source as EnemySource;

            ref var collider = ref entity.Get<ColliderComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var mutate = ref entity.Get<MutateComponent>();

            if (spawnable.id != enemyData.name)
            {
                collider.Init(enemyData);
                mutate.Init(enemyData.minSpawnScore, enemyData.maxSpawnScore);

                spawnable.id = enemyData.name;
                movable.speed = enemyData.moveDownSpeed;
            }
        }
    }
}
