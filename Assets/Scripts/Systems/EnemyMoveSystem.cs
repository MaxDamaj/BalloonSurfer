using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class EnemyMoveSystem : IEcsRunSystem
    {
        EcsFilter<MoveDownComponent, MovableComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveDown = ref _filter.Get1(i);
                ref var movable = ref _filter.Get2(i);
                moveDown.transform.position += new Vector3(0, -movable.speed, 0);

                if (moveDown.transform.position.y <= -50)
                {
                    moveDown.transform.position = new Vector3(
                        Random.Range(-30f, 30f),
                        Random.Range(MainData.Instance.enemiesInitData.minSpawnHeight, MainData.Instance.enemiesInitData.maxSpawnHeight),
                        0
                    );

                    if (SharedData.Instance.scoreValue > moveDown.maxSpawnScore)
                    {
                        _filter.GetEntity(i).Destroy();
                    }
                }
            }
        }
    }
}
