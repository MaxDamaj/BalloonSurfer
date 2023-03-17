using BalloonSurfer.Components;
using BalloonSurfer.Creators;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemiesInitData;

namespace BalloonSurfer.Systems
{
    public class EnemyMutateSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<MoveDownComponent, MovableComponent> _filter;
        private EnemyCreator _enemyCreator;

        public void Init()
        {
            _enemyCreator = new EnemyCreator();
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get1(i);
                ref var movable = ref _filter.Get2(i);

                if (moveDown.transform.position.y <= -50 && moveDown.IsMutate)
                {
                    moveDown.Spawn(MainData.Instance.fieldInitData.RandomLine);
                    _enemyCreator.Mutate(_filter.GetEntity(i));
                }
            }
        }

    }
}
