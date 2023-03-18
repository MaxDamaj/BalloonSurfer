using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Systems
{
    public class ScoreCountingSystem : IEcsRunSystem, IEcsInitSystem
    {
        public void Init()
        {
            SharedData.Instance.scoreValue = 0;
        }

        public void Run()
        {
            SharedData.Instance.scoreValue += Time.deltaTime * MainData.Instance.fieldInitData.scoresPerSecond;
        }

    }
}
