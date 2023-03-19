using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using BalloonSurfer.Systems;
using BalloonSurfer.UI;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Core
{
    public class GameLoader : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _systems = null;

        #region API

        void Start()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            var scoreSystem = new ScoreCountingSystem();

            AddSystems(new List<IEcsSystem> { scoreSystem });

            AddScoreCheckers(scoreSystem);
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

        #endregion


        private void AddSystems(List<IEcsSystem> systems)
        {
            _systems.Add(new GameInitSystem());
            _systems.Add(new PlayerMoveSideSystem());
            _systems.Add(new SpawnEnemiesSystem());
            _systems.Add(new EntityMoveSystem());
            _systems.Add(new EnemyMutateSystem());
            _systems.Add(new GameEndSystem());
            _systems.Add(new SpawnBacksSystem());
            _systems.Add(new UpdateBacksSystem());
            _systems.Add(new PauseGameSystem());
            _systems.Add(new MoveLeftRightSystem());

            foreach (var system in systems)
            {
                _systems.Add(system);
            }

            _systems.Init();
        }

        private void AddScoreCheckers(ScoreCountingSystem scoreSystem)
        {
            var scoreChecker = (IScoreUpdate)FindObjectOfType<UIMainScreenPanel>();
            scoreSystem.AddScoreChecker(scoreChecker);
        }
    }
}
