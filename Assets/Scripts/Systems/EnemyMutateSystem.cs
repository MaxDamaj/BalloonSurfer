using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class EnemyMutateSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<SpawnableComponent, MutateComponent> _filter = null;
        private EnemyCreator _enemyCreator;

        public void Init()
        {
            _enemyCreator = new EnemyCreator();
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var spawnable = ref _filter.Get1(i);
                ref var mutate = ref _filter.Get2(i);

                if (spawnable.transform.position.y <= -50 && mutate.IsMutate)
                {
                    spawnable.Spawn(MainData.Instance.fieldInitData.RandomLine);
                    _enemyCreator.Mutate(_filter.GetEntity(i));
                }
            }
        }

    }
}
