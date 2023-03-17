using BalloonSurfer.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Components
{
    public struct MoveDownComponent
    {
        public Transform transform;
        public double minSpawnScore;
        public double maxSpawnScore;

        public void Init(GameObject prefab, EnemyData enemyData)
        {
            transform = prefab.transform;
            minSpawnScore = enemyData.minSpawnScore;
            maxSpawnScore = enemyData.maxSpawnScore;
        }

        public void Spawn(int line)
        {
            transform.position = new Vector3(
                line * MainData.Instance.fieldInitData.FieldLineWidth,
                Random.Range(MainData.Instance.enemiesInitData.minSpawnHeight, MainData.Instance.enemiesInitData.maxSpawnHeight),
                0
             );
            transform.Rotate(0, 0, Random.Range(-180f, 180f));
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
