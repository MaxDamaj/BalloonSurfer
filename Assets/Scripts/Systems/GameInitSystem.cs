using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class GameInitSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsWorld _world = null;

        #region API

        public void Init()
        {
            InitPlayer();
        }

        public void Destroy()
        {

        }

        #endregion


        private void InitPlayer()
        {
            var player = _world.NewEntity();
            ref var moveSideComponent = ref player.Get<MoveSideComponent>();
            ref var movableComponent = ref player.Get<MovableComponent>();

            var playerPrefab = GameObject.Instantiate(MainData.Instance.playerInitData.prefab, Vector3.zero, Quaternion.identity);
            movableComponent.speed = MainData.Instance.playerInitData.moveSideSpeed;
            moveSideComponent.transform = playerPrefab.transform;
        }
    }
}
