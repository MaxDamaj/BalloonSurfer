using BalloonSurfer.Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BalloonSurfer.Systems {
    public class GameEndSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private EcsFilter<ColliderDetectorComponent> _filter = null;

        public void Destroy()
        {
            foreach (var i in _filter)
            {
                ref var colldetector = ref _filter.Get1(i);
                colldetector.collisionDetector.OnEnemyHit -= GameEnd;
            }
        }

        public void Init()
        {
            foreach (var i in _filter)
            {
                ref var colldetector = ref _filter.Get1(i);
                colldetector.collisionDetector.OnEnemyHit += GameEnd;
            }
        }


        private void GameEnd()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
