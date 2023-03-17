using BalloonSurfer.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemiesInitData;

namespace BalloonSurfer.Systems
{
    public class EnemyMutateSystem : IEcsRunSystem
    {
        EcsFilter<MoveDownComponent, MovableComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get1(i);
                ref var movable = ref _filter.Get2(i);

                if (moveDown.transform.position.y <= -50 && moveDown.IsMutate)
                {
                    moveDown.Spawn(MainData.Instance.fieldInitData.RandomLine);
                    MutateEnemy(_filter.GetEntity(i));
                }
            }
        }


        private void MutateEnemy(EcsEntity entity)
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
