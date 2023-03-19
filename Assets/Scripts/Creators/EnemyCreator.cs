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
            ref var sprite = ref entity.Get<SpriteComponent>();
            ref var collider = ref entity.Get<ColliderComponent>();
            ref var mutate = ref entity.Get<MutateComponent>();

            var enemyPrefab = GameObject.Instantiate(MainData.GetData<EnemiesInitData>().baseEnemyPrefab);

            moveDown.Init(enemyPrefab);
            spawnable.Init(enemyPrefab, MainData.GetData<EnemiesInitData>().minSpawnHeight, MainData.GetData<EnemiesInitData>().maxSpawnHeight, true);
            collider.Init(enemyPrefab, enemyData);
            sprite.Init(enemyPrefab);
            mutate.Init(enemyData.minSpawnScore, enemyData.maxSpawnScore);

            spawnable.id = enemyData.name;
            movable.speed = enemyData.moveDownSpeed;

            spawnable.Spawn(MainData.GetData<FieldInitData>().RandomLine);
            sprite.Init(enemyData.spriteRenderer.sprite);
        }

        public override void Mutate(MutableSource source, EcsEntity entity)
        {
            var enemyData = source as EnemySource;

            ref var sprite = ref entity.Get<SpriteComponent>();
            ref var collider = ref entity.Get<ColliderComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var mutate = ref entity.Get<MutateComponent>();

            if (spawnable.id != enemyData.name)
            {
                collider.Init(enemyData);
                mutate.Init(enemyData.minSpawnScore, enemyData.maxSpawnScore);
                sprite.Init(enemyData.spriteRenderer.sprite);

                spawnable.id = enemyData.name;
                movable.speed = enemyData.moveDownSpeed;
            }
        }
    }
}
