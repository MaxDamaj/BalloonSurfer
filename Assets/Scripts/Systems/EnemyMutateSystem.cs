using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace BalloonSurfer.Systems
{
    public class EnemyMutateSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnableComponent, MutateComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var spawnable = ref _filter.Get1(i);
                ref var mutate = ref _filter.Get2(i);

                if (spawnable.transform.position.y <= -50 && mutate.IsMutate)
                {
                    RemoveUniqueComponents(_filter.GetEntity(i));

                    spawnable.Spawn(MainData.GetData<FieldInitData>().RandomLine);
                    var enemy = MainData.GetData<EnemiesInitData>().GetRandomEnemy();
                    enemy.Creator.Mutate(enemy, _filter.GetEntity(i));
                }
            }
        }

        private void RemoveUniqueComponents(EcsEntity entity)
        {
            entity.Del<MoveLeftRightComponent>();
        }

    }
}
