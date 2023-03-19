using BalloonSurfer.EntitySources;
using BalloonSurfer.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace BalloonSurfer.InitData {
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemiesInitData")]
    public class EnemiesInitData : InitData
    {
        public int maxEnemiesOnField = 8;
        public float enemiesSpawnDelay = 4;
        public GameObject baseEnemyPrefab;
        public List<EnemySource> enemies;
        public float minSpawnHeight = 120;
        public float maxSpawnHeight = 200;

        public MutableSource GetRandomEnemy()
        {
            var score = SharedData.Instance.scoreValue;
            var enemiesData = enemies.FindAll(x => x.minSpawnScore <= score && x.maxSpawnScore >= score);
            MutableSource enemy;

            if (enemiesData.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, enemiesData.Count);
                enemy = enemiesData[randomIndex];
            }
            else
            {
                enemy = enemies.Last();
            }

            enemy.SetCreator();
            return enemy;
        }
    }
}
