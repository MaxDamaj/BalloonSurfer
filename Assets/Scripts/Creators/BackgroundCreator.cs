using BalloonSurfer.Components;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Creators
{
    public class BackgroundCreator : EntityCreator
    {
        public override void Init(EcsEntity entity)
        {
            ref var moveDown = ref entity.Get<MoveDownComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var sprite = ref entity.Get<SpriteComponent>();

            var playerPrefab = GameObject.Instantiate(MainData.Instance.backgroundsInitData.basePrefab, Vector3.zero, Quaternion.identity);

            movable.speed = MainData.Instance.backgroundsInitData.moveSpeed;
            moveDown.Init(playerPrefab);
            spawnable.Init(playerPrefab, MainData.Instance.backgroundsInitData.spawnHeight, MainData.Instance.backgroundsInitData.spawnHeight);
            sprite.Init(playerPrefab);
        }
    }
}
