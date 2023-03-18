using BalloonSurfer.InitData;
using BalloonSurfer.Systems;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Core
{
    public class GameLoader : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _systems = null;


        void Start()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.Add(new GameInitSystem());
            _systems.Add(new PlayerMoveSideSystem());
            _systems.Add(new ScoreCountingSystem());
            _systems.Add(new SpawnEnemiesSystem());
            _systems.Add(new EntityMoveSystem());
            _systems.Add(new EnemyMutateSystem());
            _systems.Add(new GameEndSystem());
            _systems.Add(new SpawnBacksSystem());
            _systems.Add(new UpdateBacksSystem());
            _systems.Add(new PauseGameSystem());

            _systems.Init();
        }

        void Update()
        {
            if (!SharedData.Instance.isGamePaused)
            {
                _systems.Run();
            }
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}
