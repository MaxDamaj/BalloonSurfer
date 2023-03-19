using BalloonSurfer.Helpers;
using BalloonSurfer.InitData;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct MutateComponent : IComponent
    {
        public double minSpawnScore;
        public double maxSpawnScore;

        public void Init(double minScore, double maxScore)
        {
            minSpawnScore = minScore;
            maxSpawnScore = maxScore;
        }

        public bool IsMutate
        {
            get
            {
                var scoreCoeff = (SharedData.Instance.scoreValue - minSpawnScore) / (maxSpawnScore - minSpawnScore);
                float rnd = Random.Range(0f, 1f);

                return scoreCoeff > rnd;
            }
        }
    }
}
