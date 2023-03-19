using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class ScoreCountingSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private List<IScoreUpdate> _scoreUpdates = null;

        public void Destroy()
        {
            SharedData.Instance.scoreValue = 0;
        }

        public void Init()
        {
            SharedData.Instance.scoreValue = 0;
            _scoreUpdates = new List<IScoreUpdate>();
        }

        public void Run()
        {
            SharedData.Instance.scoreValue += Time.deltaTime * MainData.GetData<FieldInitData>().scoresPerSecond;

            foreach (var scoreUpdate in _scoreUpdates)
            {
                scoreUpdate.UpdateScore((int)SharedData.Instance.scoreValue);
            }
        }


        public void AddScoreChecker(IScoreUpdate scoreUpdate)
        {
            _scoreUpdates.Add(scoreUpdate);
        }

    }
}
